using Comix.Delivery100.SDK.Models;
using Furion.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Delivery100.SDK.Interfaces
{
    public interface IDeliveryService : IScoped
    {
        /// <summary>
        /// SubscribeAsync
        /// </summary>
        /// <param name="orderCode">订单号</param>
        /// <param name="company">订阅的快递公司的编码，一律用小写字母</param>
        /// <param name="number">订阅的快递单号，单号的最大长度是32个字符</param>
        /// <param name="phone">收、寄件人的电话号码（手机和固定电话均可，只能填写一个，顺丰单号必填，其他快递公司选填。如座机号码有分机号，分机号无需上传。）</param>
        /// <returns></returns>
        Task<SubscribeRespModel> SubscribeAsync(string orderCode, string company, string number, string phone);
    }
}
