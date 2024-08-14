using System;
using DotNetCore.CAP.RocketMQ4;

namespace DotNetCore.CAP.RabbitMQ
{
    /// <summary>
    /// 使用rocketmq时 topic中@后面的为tag，$后面表示动态生成
    /// <example>
    /// topic: TOPIC-COS-MALL-PRODUCT-UAT@mall-product
    /// 意思是监听TOPIC-COS-MALL-PRODUCT-UAT主题中tag为mall-product的消息
    /// </example>
    /// </summary>
    public static class CapOptionsExtensions
    {
        public static CapOptions UseRocketMQ(this CapOptions options, string onsNameSrv)
        {
            return options.UseRocketMQ(opt => { opt.OnsNameSrv = onsNameSrv; });
        }

        public static CapOptions UseRocketMQ(this CapOptions options, Action<RocketMQOptions> configure)
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            options.RegisterExtension(new RabbitMQCapOptionsExtension(configure));

            return options;
        }
    }
}