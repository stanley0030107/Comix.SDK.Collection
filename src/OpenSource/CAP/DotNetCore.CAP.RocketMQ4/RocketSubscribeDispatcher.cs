using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
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
    public class RocketSubscribeDispatcher : ISubscribeDispatcher
    {
        private readonly IDataStorage _dataStorage;
        private readonly ILogger _logger;
        private readonly RocketMQOptions _rocketOptions;
        private readonly IServiceProvider _provider;
        private readonly CapOptions _options;

        // diagnostics listener
        // ReSharper disable once InconsistentNaming
        private static readonly DiagnosticListener s_diagnosticListener =
            new DiagnosticListener(CapDiagnosticListenerNames.DiagnosticListenerName);

        public RocketSubscribeDispatcher(
            ILogger<RocketSubscribeDispatcher> logger,
            IOptions<CapOptions> options,
            IOptions<RocketMQOptions> rocketOptions,
            IServiceProvider provider)
        {
            _provider = provider;
            _logger = logger;
            _rocketOptions = rocketOptions.Value;
            _options = options.Value;

            _dataStorage = _provider.GetService<IDataStorage>();
            Invoker = _provider.GetService<ISubscribeInvoker>();
        }

        private ISubscribeInvoker Invoker { get; }

        public Task<OperateResult> DispatchAsync(MediumMessage message, CancellationToken cancellationToken)
        {
            var selector = _provider.GetService<MethodMatcherCache>();

            var name = message.Origin.GetName();
            if (message.Origin.Headers.TryGetValue("Tag", out var value))
            {
                name += $"@{value}";
            }
            
            if (!selector.TryGetTopicExecutor(name, message.Origin.GetGroup(), out var executor))
            {
                name = message.Origin.GetName();
                name += $"@*";
                if (!selector.TryGetTopicExecutor(name, message.Origin.GetGroup(), out executor))
                {
                    if (!_rocketOptions.LogNotSubscrib)
                    {
                        return Task.FromResult(OperateResult.Success);
                    }
                    
                    var error =
                        $"Message (Name:{name},Group:{message.Origin.GetGroup()}) can not be found subscriber." +
                        $"{Environment.NewLine} see: https://github.com/dotnetcore/CAP/issues/63";
                    _logger.LogError(error);

                    TracingError(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), message.Origin, null,
                        new Exception(error));

                    return Task.FromResult(OperateResult.Failed(new SubscriberNotFoundException(error)));
                }
            }

            return DispatchAsync(message, executor, cancellationToken);
        }

        public async Task<OperateResult> DispatchAsync(MediumMessage message, ConsumerExecutorDescriptor descriptor, CancellationToken cancellationToken)
        {
            bool retry;
            OperateResult result;
            do
            {
                var executedResult = await ExecuteWithoutRetryAsync(message, descriptor, cancellationToken);
                result = executedResult.Item2;
                if (result == OperateResult.Success)
                {
                    return result;
                }
                retry = executedResult.Item1;
            } while (retry);

            return result;
        }

        private async Task<(bool, OperateResult)> ExecuteWithoutRetryAsync(MediumMessage message, ConsumerExecutorDescriptor descriptor, CancellationToken cancellationToken)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var sp = Stopwatch.StartNew();

                await InvokeConsumerMethodAsync(message, descriptor, cancellationToken);

                sp.Stop();

                await SetSuccessfulState(message);
                
                _logger.LogDebug($"Consumer executed. Took: {sp.Elapsed.TotalMilliseconds} ms.");

                return (false, OperateResult.Success);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occurred while executing the subscription method. Topic:{message.Origin.GetName()}, Id:{message.DbId}");

                return (await SetFailedState(message, ex), OperateResult.Failed(ex));
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
            {
                message.Retries = _options.FailedRetryCount; // not retry if SubscriberNotFoundException
            }

            var needRetry = UpdateMessageForRetry(message);

            message.ExpiresAt = message.Added.AddDays(15);

            await _dataStorage.ChangeReceiveStateAsync(message, StatusName.Failed);

            return needRetry;
        }

        private bool UpdateMessageForRetry(MediumMessage message)
        {
            var retries = ++message.Retries;

            var retryCount = Math.Min(_options.FailedRetryCount, 3);
            if (retries >= retryCount)
            {
                if (retries == _options.FailedRetryCount)
                {
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
                }
                return false;
            }

            _logger.LogWarning($"The {retries}th retrying consume a message failed. message id: {message.DbId}");

            return true;
        }

        //private static void AddErrorReasonToContent(CapReceivedMessage message, Exception exception)
        //{
        //    message.Content = Helper.AddExceptionProperty(message.Content, exception);
        //}

        private async Task InvokeConsumerMethodAsync(MediumMessage message, ConsumerExecutorDescriptor descriptor, CancellationToken cancellationToken)
        {
            var consumerContext = new ConsumerContext(descriptor, message.Origin);
            var tracingTimestamp = TracingBefore(message.Origin, descriptor.MethodInfo);
            try
            {
                var ret = await Invoker.InvokeAsync(consumerContext, cancellationToken);

                TracingAfter(tracingTimestamp, message.Origin, descriptor.MethodInfo);

                if (!string.IsNullOrEmpty(ret.CallbackName))
                {
                    var header = new Dictionary<string, string>()
                    {
                        [Headers.CorrelationId] = message.Origin.GetId(),
                        [Headers.CorrelationSequence] = (message.Origin.GetCorrelationSequence() + 1).ToString()
                    };

                    await _provider.GetService<ICapPublisher>().PublishAsync(ret.CallbackName, ret.Result, header, cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                //ignore
            }
            catch (Exception ex)
            {
                var e = new Exception(ex.Message, ex);

                TracingError(tracingTimestamp, message.Origin, descriptor.MethodInfo, e);

                throw e;
            }
        }

        #region tracing

        private long? TracingBefore(Message message, MethodInfo method)
        {
            if (s_diagnosticListener.IsEnabled(CapDiagnosticListenerNames.BeforeSubscriberInvoke))
            {
                var eventData = new CapEventDataSubExecute()
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
            if (tracingTimestamp != null && s_diagnosticListener.IsEnabled(CapDiagnosticListenerNames.AfterSubscriberInvoke))
            {
                var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                var eventData = new CapEventDataSubExecute()
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

        private void TracingError(long? tracingTimestamp, Message message, MethodInfo method, Exception ex)
        {
            if (tracingTimestamp != null && s_diagnosticListener.IsEnabled(CapDiagnosticListenerNames.ErrorSubscriberInvoke))
            {
                var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                var eventData = new CapEventDataSubExecute()
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