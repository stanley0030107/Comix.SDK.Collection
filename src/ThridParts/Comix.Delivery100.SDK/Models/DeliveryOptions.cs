using Furion.ConfigurableOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Delivery100.SDK.Models
{
    public class DeliveryOptions : IConfigurableOptions
    {
        /// <summary>
        /// Delivery请求地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 我方分配给贵司的的授权key
        /// </summary>
        public string Logisticskey { get; set; }
        /// <summary>
        /// 回调接口的地址。如果需要在推送信息回传自己业务参数，可以在回调地址URL后面拼接上去
        /// </summary>
        public string SubscribeCallbackUrl { get; set; }
        /// <summary>
        /// 签名用随机字符串。32位自定义字符串。添加该参数，则推送的时候会增加sign给贵司校验消息的可靠性
        /// </summary>
        public string SignSalt { get; set; }

        public string logistics { get; set; }
    }
}
