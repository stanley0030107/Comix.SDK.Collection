using DotNetCore.CAP.Messages;
using DotNetCore.CAP.Transport;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NewLife;
using NewLife.RocketMQ;

namespace DotNetCore.CAP.RocketMQ4
{
    public class RocketMQConsumerClient : IConsumerClient
    {
        private readonly RocketMQOptions _rocketMqOptions;
        private readonly string _groupId;
        private readonly ILogger _logger;
        private Dictionary<string, Consumer> _consumers;

        public RocketMQConsumerClient(string groupId,
            IOptions<RocketMQOptions> options,
            ILogger logger)
        {
            _groupId = groupId;
            _logger = logger;
            _rocketMqOptions = options.Value;
            _consumers = new Dictionary<string, Consumer>();
        }
        
        public void Dispose()
        {
            foreach (var consumer in _consumers.Values)
            {
                consumer.TryDispose();
            }
        }

        public BrokerAddress BrokerAddress => new BrokerAddress("RocketMQ", _rocketMqOptions.OnsNameSrv);
        public void Subscribe(IEnumerable<string> topics)
        {
            foreach (var topic in topics.Distinct())
            {
                var t = topic;
                if (topic.Contains("@"))
                {
                    t = topic.Split('@')[0];
                }
                var consumer = new Consumer
                {
                    Topic = t,
                    Group = _groupId.TrimEnd(".v1".ToCharArray()),
                    NameServerAddress = _rocketMqOptions.OnsNameSrv,
                    SecretKey = _rocketMqOptions.OnsSecretKey,
                    AccessKey = _rocketMqOptions.OnsAccessKey,
                    ConsumerInterval = _rocketMqOptions.ConsumerInterval,
                    FromLastOffset = true,
                    SkipOverStoredMsgCount = 0
                };

                if (!_consumers.ContainsKey(t))
                {
                    _consumers.Add(t, consumer);
                }
            }
        }

        public void Listening(TimeSpan timeout, CancellationToken cancellationToken)
        {
            foreach (var consumer in _consumers.Values)
            {
                consumer.OnConsume = (q, ms) =>
                {
                    foreach (var item in ms.ToList())
                    {
                        _logger.LogInformation(
                            "Received Message. MessageId:{ItemMsgId}, Name:{ItemTags}, Group:{ItemTopic}", item.MsgId,
                            item.Topic, consumer.Group);
                        _logger.LogInformation("MessageId:{ItemMsgId}, Content:{ItemBody}", item.MsgId, item.BodyString);

                        Dictionary<string, string> headers = new Dictionary<string, string>();
                        headers.Add(Messages.Headers.MessageId, item.MsgId);
                        headers.Add(Messages.Headers.MessageName, item.Topic);
                        headers.Add("Tag", item.Tags);
                        headers.Add(Messages.Headers.Group, $"{consumer.Group}.v1" );
                        var message = new TransportMessage(headers, item.Body.ToArray());
                        OnMessageCallback!(message, headers).GetAwaiter().GetResult();
                    }

                    return true;
                };
                
                var b = consumer.Start();
            }

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                cancellationToken.WaitHandle.WaitOne(timeout);
            }
        }

        public void Commit(object sender)
        {
  
        }

        public void Reject(object sender)
        {
            
        }

        public Func<TransportMessage, object?, Task>? OnMessageCallback { get; set; }
        public Action<LogMessageEventArgs>? OnLogCallback { get; set; }
    }
}