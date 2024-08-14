using System.Diagnostics;
using DotNetCore.CAP.Diagnostics;
using DotNetCore.CAP.Internal;
using DotNetCore.CAP.Messages;
using DotNetCore.CAP.Persistence;
using DotNetCore.CAP.Serialization;
using DotNetCore.CAP.Transport;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DotNetCore.CAP.RocketMQ4
{
    public class RocketConsumerRegister : IConsumerRegister
    {
        private readonly ILogger _logger;
        private readonly CapOptions _options;
        private readonly TimeSpan _pollingDelay = TimeSpan.FromSeconds(1);
        private readonly IServiceProvider _serviceProvider;
        private Task? _compositeTask;

        private IConsumerClientFactory _consumerClientFactory = default!;
        private CancellationTokenSource _cts = new();
        private IDispatcher _dispatcher = default!;
        private bool _disposed;
        private bool _isHealthy = true;

        private MethodMatcherCache _selector = default!;
        private ISerializer _serializer = default!;
        private BrokerAddress _serverAddress;
        private IDataStorage _storage = default!;

        // diagnostics listener
        // ReSharper disable once InconsistentNaming
        private static readonly DiagnosticListener s_diagnosticListener =
            new DiagnosticListener(CapDiagnosticListenerNames.DiagnosticListenerName);

        public RocketConsumerRegister(ILogger<RocketConsumerRegister> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _options = serviceProvider.GetRequiredService<IOptions<CapOptions>>().Value;
        }

        public bool IsHealthy()
        {
            return _isHealthy;
        }

        public void ReStart(bool force = false)
        {
            if (!IsHealthy() || force)
            {
                Pulse();

                _cts = new CancellationTokenSource();
                _isHealthy = true;

                Execute();
            }
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;

            try
            {
                Pulse();

                _compositeTask?.Wait(TimeSpan.FromSeconds(2));
            }
            catch (AggregateException ex)
            {
                var innerEx = ex.InnerExceptions[0];
                if (!(innerEx is OperationCanceledException))
                {
                    _logger.LogWarning(ex, $"Expected an OperationCanceledException, but found '{innerEx.Message}'.");
                }
            }
        }

        public Task Start(CancellationToken stoppingToken)
        {
            _cts = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
            _cts.Token.Register(Dispose);

            _selector = _serviceProvider.GetRequiredService<MethodMatcherCache>();
            _dispatcher = _serviceProvider.GetRequiredService<IDispatcher>();
            _serializer = _serviceProvider.GetRequiredService<ISerializer>();
            _storage = _serviceProvider.GetRequiredService<IDataStorage>();
            _consumerClientFactory = _serviceProvider.GetRequiredService<IConsumerClientFactory>();

            Execute();

            _disposed = false;

            return Task.CompletedTask;
        }

        public void Pulse()
        {
            _cts.Cancel();
            _cts.Dispose();
        }

        private void RegisterMessageProcessor(IConsumerClient client)
        {
            client.OnLogCallback += WriteLog;
            client.OnMessageCallback = async (transportMessage, sender) =>
            {
                long? tracingTimestamp = null;
                try
                {
                    _logger.LogDebug(
                        $"Received message. id:{transportMessage.GetId()}, name: {transportMessage.GetName()}");
                    tracingTimestamp = TracingBefore(transportMessage, _serverAddress);

                    var name = transportMessage.GetName();
                    if (transportMessage.Headers.TryGetValue("Tag", out var value))
                    {
                        name += $"@{value}";
                    }

                    var group = transportMessage.GetGroup();

                    Message message;

                    var canFindSubscriber = _selector.TryGetTopicExecutor(name, group, out var executor);
                    try
                    {
                        if (!canFindSubscriber)
                        {
                            name = transportMessage.GetName();
                            name += $"@*";
                            canFindSubscriber = _selector.TryGetTopicExecutor(name, group, out executor);
                            if (!canFindSubscriber)
                            {
                                var error =
                                    $"Message can not be found subscriber. Name:{name}, Group:{group}. {Environment.NewLine} see: https://github.com/dotnetcore/CAP/issues/63";
                                var ex = new SubscriberNotFoundException(error);

                                TracingError(tracingTimestamp, transportMessage, client.BrokerAddress, ex);

                                throw ex;
                            }
                        }

                        var type = executor!.Parameters.FirstOrDefault(x => x.IsFromCap == false)?.ParameterType;
                        message = await _serializer.DeserializeAsync(transportMessage, type);
                        message.RemoveException();
                    }
                    catch (Exception e)
                    {
                        transportMessage.Headers[Headers.Exception] = e.GetType().Name + "-->" + e.Message;
                        string? dataUri;
                        if (transportMessage.Headers.TryGetValue(Headers.Type, out var val))
                        {
                            if (transportMessage.Body.Length != 0)
                                dataUri = $"data:{val};base64," + Convert.ToBase64String(transportMessage.Body.Span);
                            else
                                dataUri = null;
                            message = new Message(transportMessage.Headers, dataUri);
                        }
                        else
                        {
                            if (transportMessage.Body.Length != 0)
                                dataUri = "data:UnknownType;base64," +
                                          Convert.ToBase64String(transportMessage.Body.Span);
                            else
                                dataUri = null;
                            message = new Message(transportMessage.Headers, dataUri);
                        }
                    }

                    if (message.HasException())
                    {
                        var content = _serializer.Serialize(message);

                        await _storage.StoreReceivedExceptionMessageAsync(name, group, content);

                        client.Commit(sender);

                        try
                        {
                            _options.FailedThresholdCallback?.Invoke(new FailedInfo
                            {
                                ServiceProvider = _serviceProvider,
                                MessageType = MessageType.Subscribe,
                                Message = message
                            });

                            _logger.LogWarning(
                                $"The Subscriber of the message({message.GetId()}) still fails after {_options.FailedRetryCount}th executions and we will stop retrying.");
                        }
                        catch (Exception e)
                        {
                            _logger.LogWarning(e, "FailedThresholdCallback action raised an exception:" + e.Message);
                        }

                        TracingAfter(tracingTimestamp, transportMessage, _serverAddress);
                    }
                    else
                    {
                        var mediumMessage = await _storage.StoreReceivedMessageAsync(name, group, message);
                        mediumMessage.Origin = message;

                        TracingAfter(tracingTimestamp, transportMessage, _serverAddress);

                        await _dispatcher.EnqueueToExecute(mediumMessage, executor!);

                        client.Commit(sender);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "An exception occurred when process received message. Message:'{0}'.",
                        transportMessage);

                    client.Reject(sender);

                    TracingError(tracingTimestamp, transportMessage, client.BrokerAddress, e);
                }
            };
        }
  public void Execute()
    {
        var groupingMatches = _selector.GetCandidatesMethodsOfGroupNameGrouped();

        foreach (var matchGroup in groupingMatches)
        {
            for (int i = 0; i < _options.ConsumerThreadCount; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        using (var client = _consumerClientFactory.Create(matchGroup.Key))
                        {
                            _serverAddress = client.BrokerAddress;

                            RegisterMessageProcessor(client);

                            client.Subscribe(matchGroup.Value.Select(x => x.TopicName));

                            client.Listening(_pollingDelay, _cts.Token);
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        //ignore
                    }
                    catch (BrokerConnectionException e)
                    {
                        _isHealthy = false;
                        _logger.LogError(e, e.Message);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e, e.Message);
                    }
                }, _cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            }
        }

        _compositeTask = Task.CompletedTask;
    }
        private void WriteLog(LogMessageEventArgs logmsg)
        {
            switch (logmsg.LogType)
            {
                case MqLogType.ConsumerCancelled:
                    _logger.LogWarning("RabbitMQ consumer cancelled. --> " + logmsg.Reason);
                    break;
                case MqLogType.ConsumerRegistered:
                    _isHealthy = true;
                    _logger.LogInformation("RabbitMQ consumer registered. --> " + logmsg.Reason);
                    break;
                case MqLogType.ConsumerUnregistered:
                    _logger.LogWarning("RabbitMQ consumer unregistered. --> " + logmsg.Reason);
                    break;
                case MqLogType.ConsumerShutdown:
                    _isHealthy = false;
                    _logger.LogWarning("RabbitMQ consumer shutdown. --> " + logmsg.Reason);
                    break;
                case MqLogType.ConsumeError:
                    _logger.LogError("Kafka client consume error. --> " + logmsg.Reason);
                    break;
                case MqLogType.ConsumeRetries:
                    _logger.LogWarning("Kafka client consume exception, retying... --> " + logmsg.Reason);
                    break;
                case MqLogType.ServerConnError:
                    _isHealthy = false;
                    _logger.LogCritical("Kafka server connection error. --> " + logmsg.Reason);
                    break;
                case MqLogType.ExceptionReceived:
                    _logger.LogError("AzureServiceBus subscriber received an error. --> " + logmsg.Reason);
                    break;
                case MqLogType.AsyncErrorEvent:
                    _logger.LogError("NATS subscriber received an error. --> " + logmsg.Reason);
                    break;
                case MqLogType.ConnectError:
                    _isHealthy = false;
                    _logger.LogError("NATS server connection error. -->  " + logmsg.Reason);
                    break;
                case MqLogType.InvalidIdFormat:
                    _logger.LogError(
                        "AmazonSQS subscriber delete inflight message failed, invalid id. --> " + logmsg.Reason);
                    break;
                case MqLogType.MessageNotInflight:
                    _logger.LogError(
                        "AmazonSQS subscriber change message's visibility failed, message isn't in flight. --> " +
                        logmsg.Reason);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #region tracing

        private long? TracingBefore(TransportMessage message, BrokerAddress broker)
        {
            if (s_diagnosticListener.IsEnabled(CapDiagnosticListenerNames.BeforeConsume))
            {
                var eventData = new CapEventDataSubStore
                {
                    OperationTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                    Operation = message.GetName(),
                    BrokerAddress = broker,
                    TransportMessage = message
                };

                s_diagnosticListener.Write(CapDiagnosticListenerNames.BeforeConsume, eventData);

                return eventData.OperationTimestamp;
            }

            return null;
        }

        private void TracingAfter(long? tracingTimestamp, TransportMessage message, BrokerAddress broker)
        {
            CapEventCounterSource.Log.WriteConsumeMetrics();
            if (tracingTimestamp != null && s_diagnosticListener.IsEnabled(CapDiagnosticListenerNames.AfterConsume))
            {
                var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                var eventData = new CapEventDataSubStore
                {
                    OperationTimestamp = now,
                    Operation = message.GetName(),
                    BrokerAddress = broker,
                    TransportMessage = message,
                    ElapsedTimeMs = now - tracingTimestamp.Value
                };

                s_diagnosticListener.Write(CapDiagnosticListenerNames.AfterConsume, eventData);
            }
        }

        private void TracingError(long? tracingTimestamp, TransportMessage message, BrokerAddress broker, Exception ex)
        {
            if (tracingTimestamp != null && s_diagnosticListener.IsEnabled(CapDiagnosticListenerNames.ErrorConsume))
            {
                var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

                var eventData = new CapEventDataSubStore
                {
                    OperationTimestamp = now,
                    Operation = message.GetName(),
                    BrokerAddress = broker,
                    TransportMessage = message,
                    ElapsedTimeMs = now - tracingTimestamp.Value,
                    Exception = ex
                };

                s_diagnosticListener.Write(CapDiagnosticListenerNames.ErrorConsume, eventData);
            }
        }

        #endregion
    }
}