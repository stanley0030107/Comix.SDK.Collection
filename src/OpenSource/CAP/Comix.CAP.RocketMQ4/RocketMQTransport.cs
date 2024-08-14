using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.CAP.Internal;
using DotNetCore.CAP.Messages;
using DotNetCore.CAP.Transport;
using Microsoft.Extensions.Options;
using NewLife.RocketMQ;
using NewLife.RocketMQ.Protocol;

namespace DotNetCore.CAP.RocketMQ4
{
    public class RocketMQTransport : ITransport
    {
        private readonly RocketMQOptions _rocketMqOptions;
        private Dictionary<string, Producer> _producers;

        public RocketMQTransport(IOptions<RocketMQOptions> options)
        {
            _rocketMqOptions = options.Value;
            _producers = new Dictionary<string, Producer>();
        }

        public BrokerAddress BrokerAddress => new BrokerAddress("RabbitMQ", _rocketMqOptions.OnsNameSrv);

        private static object _l = new object();

        /// <summary>
        /// 获取Producer
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        private Producer GetProducer(string topic)
        {
            var b = _producers.TryGetValue(topic, out var producer);
            if (!b)
            {
                lock (_l)
                {
                    b = _producers.TryGetValue(topic, out producer);
                    if (b)
                    {
                        return producer;
                    }
                    producer = CreateProducer(topic);
                    _producers.Add(topic, producer);
                }
            }

            return producer;
        }

        /// <summary>
        /// 创建Producer
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        private Producer CreateProducer(string topic)
        {
            try
            {
                var mq = new Producer
                {
                    Topic = topic,
                    NameServerAddress = _rocketMqOptions.OnsNameSrv,
                    AccessKey = _rocketMqOptions.OnsAccessKey,
                    SecretKey = _rocketMqOptions.OnsSecretKey,
                    Group = "GID-COP-ORDER-TEST"
                };
              
                mq.Start();
                return mq;
            }
            catch (ResponseException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        private Producer Refresh(string topic)
        {
            _producers.Remove(topic);
            return CreateProducer(topic);
        }

        public async Task<OperateResult> SendAsync(TransportMessage message)
        {
            try
            {
                var name = message.GetName();
                string topic;
                string tag;
                if (name.Contains("@"))
                {
                    var names = name.Split('@');
                    topic = names[0];
                    tag = names[1];
                }
                else
                {
                    topic = name;
                    tag = name;
                }
                
                var producer = GetProducer(topic);
                if (producer.Disposed)
                {
                    producer = Refresh(topic);
                }
                var result = await producer.PublishAsync(message.Body, tag);
                if (result.Status == SendStatus.SendOK)
                {
                    return OperateResult.Success;
                }

                throw new Exception($"RabbitMQ topic message [{message.GetName()}] publish fail, status: {result.Status}.");
            }
            catch (Exception ex)
            {
                var wrapperEx = new PublisherSentFailedException(ex.Message, ex);
                var errors = new OperateError
                {
                    Code = ex.HResult.ToString(),
                    Description = ex.Message
                };

                return OperateResult.Failed(wrapperEx, errors);
            }
        }
    }
}