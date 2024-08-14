using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.CAP.Diagnostics;
using DotNetCore.CAP.Internal;
using DotNetCore.CAP.Messages;
using DotNetCore.CAP.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DotNetCore.CAP.RocketMQ4
{
    public class RocketSubscribeExecutor : ISubscribeExecutor
    {
        private readonly IDataStorage _dataStorage;
        private readonly string? _hostName;
        private readonly ILogger _logger;
        private readonly IServiceProvider _provider;
        private readonly CapOptions _options;

        // diagnostics listener
        // ReSharper disable once InconsistentNaming
        private static readonly DiagnosticListener s_diagnosticListener =
            new DiagnosticListener(CapDiagnosticListenerNames.DiagnosticListenerName);

        public RocketSubscribeExecutor(
            ILogger<RocketSubscribeExecutor> logger,
            IOptions<CapOptions> options,
            IServiceProvider provider)
        {
            _provider = provider;
            _logger = logger;
            _options = options.Value;

            _dataStorage = _provider.GetRequiredService<IDataStorage>();
            Invoker = _provider.GetRequiredService<ISubscribeInvoker>();
            _hostName = Helper.GetInstanceHostname();
        }

        private ISubscribeInvoker Invoker { get; }

        private async Task<(bool, OperateResult)> ExecuteWithoutRetryAsync(MediumMessage message,
            ConsumerExecutorDescriptor descriptor, CancellationToken cancellationToken)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                _logger.LogInformation($"Executing subscriber method '{descriptor.ImplTypeInfo.Name}.{descriptor.MethodInfo.Name}' on group '{descriptor.Attribute.Group}'");

                var sp = Stopwatch.StartNew();

                await InvokeConsumerMethodAsync(message, descriptor, cancellationToken).ConfigureAwait(false);

                sp.Stop();

                await SetSuccessfulState(message).ConfigureAwait(false);

                CapEventCounterSource.Log.WriteInvokeTimeMetrics(sp.Elapsed.TotalMilliseconds);
                _logger.LogWarning(
                    $"The Subscriber of the message({descriptor.ImplTypeInfo.Name}) still fails after {descriptor.MethodInfo.Name}th executions and we will stop retrying.");
                
                return (false, OperateResult.Success);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    $"An exception occurred while executing the subscription method. Topic:{message.Origin.GetName()}, Id:{message.DbId}, Instance: {message.Origin.GetExecutionInstanceId()}");

                return (await SetFailedState(message, ex).ConfigureAwait(false), OperateResult.Failed(ex));
            }
        }

        private Task SetSuccessfulState(MediumMessage message)
        {
            message.ExpiresAt = DateTime.Now.AddSeconds(_options.SucceedMessageExpiredAfter);

            return _dataStorage.ChangeReceiveStateAsync(message, StatusName.Succeeded);
        }

        private async Task<bool> SetFailedState(MediumMessage message, Exception ex)
        {
            if (ex is SubscriberNotFoundException)
                message.Retries = _options.FailedRetryCount; // not retry if SubscriberNotFoundException

            var needRetry = UpdateMessageForRetry(message);

            message.Origin.AddOrUpdateException(ex);
            message.ExpiresAt = message.Added.AddSeconds(_options.FailedMessageExpiredAfter);

            await _dataStorage.ChangeReceiveStateAsync(message, StatusName.Failed).ConfigureAwait(false);

            return needRetry;
        }

        private bool UpdateMessageForRetry(MediumMessage message)
        {
            var retries = ++message.Retries;

            var retryCount = Math.Min(_options.FailedRetryCount, 3);
            if (retries >= retryCount)
            {
                if (retries == _options.FailedRetryCount)
                    try
                    {
                        _options.FailedThresholdCallback?.Invoke(new FailedInfo
                        {
                            ServiceProvider = _provider,
                            MessageType = MessageType.Subscribe,
                            Message = message.Origin
                        });
                        _logger.LogWarning(
                            $"The Subscriber of the message({message.DbId}) still fails after {_options.FailedRetryCount}th executions and we will stop retrying.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "FailedThresholdCallback action raised an exception:" + ex.Message);
                    }

                return false;
            }

            _logger.LogWarning($"The {retries}th retrying consume a message failed. message id: {message.DbId}");

            return true;
        }

       
        public async Task<OperateResult> ExecuteAsync(MediumMessage message, ConsumerExecutorDescriptor? descriptor = null,
            CancellationToken cancellationToken = default)
        {
            if (descriptor == null)
            {
                var name = message.Origin.GetName();
                if (message.Origin.Headers.TryGetValue("Tag", out var value))
                {
                    name += $"@{value}";
                }
                
                var selector = _provider.GetRequiredService<MethodMatcherCache>();
                if (!selector.TryGetTopicExecutor(name, message.Origin.GetGroup()!, out descriptor))
                {
                    name = message.Origin.GetName();
                    name += $"@*";
                    
                    if (!selector.TryGetTopicExecutor(name, message.Origin.GetGroup()!, out descriptor))
                    {
                        var error =
                            $"Message (Name:{name},Group:{message.Origin.GetGroup()}) can not be found subscriber." +
                            $"{Environment.NewLine} see: https://github.com/dotnetcore/CAP/issues/63";
                        _logger.LogError(error);

                        TracingError(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), message.Origin, null,
                            new Exception(error));

                        return OperateResult.Failed(new SubscriberNotFoundException(error));
                    }
                }
            }

            bool retry;
            OperateResult result;

            //record instance id
            message.Origin.Headers[Headers.ExecutionInstanceId] = _hostName;

            do
            {
                var (shouldRetry, operateResult) =
                    await ExecuteWithoutRetryAsync(message, descriptor, cancellationToken).ConfigureAwait(false);
                result = operateResult;
                if (result.Equals(OperateResult.Success)) return result;
                retry = shouldRetry;
            } while (retry);

            return result;
        }

        private async Task InvokeConsumerMethodAsync(MediumMessage message, ConsumerExecutorDescriptor descriptor,
            CancellationToken cancellationToken)
        {
            var consumerContext = new ConsumerContext(descriptor, message.Origin);
            var tracingTimestamp = TracingBefore(message.Origin, descriptor.MethodInfo);
            try
            {
                var ret = await Invoker.InvokeAsync(consumerContext, cancellationToken).ConfigureAwait(false);

                TracingAfter(tracingTimestamp, message.Origin, descriptor.MethodInfo);

                if (!string.IsNullOrEmpty(ret.CallbackName))
                {
                    var header = new Dictionary<string, string?>
                    {
                        [Headers.CorrelationId] = message.Origin.GetId(),
                        [Headers.CorrelationSequence] = (message.Origin.GetCorrelationSequence() + 1).ToString()
                    };

                    await _provider.GetRequiredService<ICapPublisher>()
                        .PublishAsync(ret.CallbackName, ret.Result, header, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (OperationCanceledException)
            {
                //ignore
            }
            catch (Exception ex)
            {
                var e = new Comix.CAP.RocketMQ4.SubscriberExecutionFailedException(ex.Message, ex);

                TracingError(tracingTimestamp, message.Origin, descriptor.MethodInfo, e);
                
                ExceptionDispatchInfo.Capture(e).Throw();
            }
        }
    #region tracing

    private long? TracingBefore(Message message, MethodInfo method)
    {
        if (s_diagnosticListener.IsEnabled(CapDiagnosticListenerNames.BeforeSubscriberInvoke))
        {
            var eventData = new CapEventDataSubExecute
            {
                OperationTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                Operation = message.GetName(),
                Message = message,
                MethodInfo = method
            };

            s_diagnosticListener.Write(CapDiagnosticListenerNames.BeforeSubscriberInvoke, eventData);

            return eventData.OperationTimestamp;
        }

        return null;
    }

    private void TracingAfter(long? tracingTimestamp, Message message, MethodInfo method)
    {
        CapEventCounterSource.Log.WriteInvokeMetrics();
        if (tracingTimestamp != null &&
            s_diagnosticListener.IsEnabled(CapDiagnosticListenerNames.AfterSubscriberInvoke))
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var eventData = new CapEventDataSubExecute
            {
                OperationTimestamp = now,
                Operation = message.GetName(),
                Message = message,
                MethodInfo = method,
                ElapsedTimeMs = now - tracingTimestamp.Value
            };

            s_diagnosticListener.Write(CapDiagnosticListenerNames.AfterSubscriberInvoke, eventData);
        }
    }

    private void TracingError(long? tracingTimestamp, Message message, MethodInfo? method, Exception ex)
    {
        if (tracingTimestamp != null &&
            s_diagnosticListener.IsEnabled(CapDiagnosticListenerNames.ErrorSubscriberInvoke))
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var eventData = new CapEventDataSubExecute
            {
                OperationTimestamp = now,
                Operation = message.GetName(),
                Message = message,
                MethodInfo = method,
                ElapsedTimeMs = now - tracingTimestamp.Value,
                Exception = ex
            };

            s_diagnosticListener.Write(CapDiagnosticListenerNames.ErrorSubscriberInvoke, eventData);
        }
    }

    #endregion
    }
}