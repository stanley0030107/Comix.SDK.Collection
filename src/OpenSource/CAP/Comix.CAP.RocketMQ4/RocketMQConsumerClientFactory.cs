using DotNetCore.CAP.Transport;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DotNetCore.CAP.RocketMQ4
{
    internal sealed class RocketMQConsumerClientFactory : IConsumerClientFactory
    {
        private readonly IOptions<RocketMQOptions> _rocketMqOptions;
        private readonly ILogger<RocketMQConsumerClientFactory> _logger;

        public RocketMQConsumerClientFactory(IOptions<RocketMQOptions> rocketMQOptions, 
            ILogger<RocketMQConsumerClientFactory> logger)
        {
            _rocketMqOptions = rocketMQOptions;
            _logger = logger;
        }

        public IConsumerClient Create(string groupId)
        {
            try
            {
                var client = new RocketMQConsumerClient(groupId, _rocketMqOptions, _logger);
                return client;
            }
            catch (System.Exception e)
            {
                throw new BrokerConnectionException(e);
            }
        }
    }
}