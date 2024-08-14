using Comix.Delivery100.SDK.Interfaces;
using Comix.Delivery100.SDK.Models;
using Furion.RemoteRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furion;
using Furion.RemoteRequest.Extensions;

namespace Comix.Delivery100.SDK.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryHttpClient _deliveryHttpClient;
        private readonly DeliveryOptions _deliveryOptions;

        public DeliveryService(
            IOptions<DeliveryOptions> deliveryOptions, IDeliveryHttpClient deliveryHttpClient)
        {
            _deliveryOptions = deliveryOptions.Value;
            _deliveryHttpClient = deliveryHttpClient;
        }

        /// <summary>
        /// SubscribeAsync
        /// </summary>
        /// <param name="orderCode">订单号</param>
        /// <param name="company">订阅的快递公司的编码，一律用小写字母</param>
        /// <param name="number">订阅的快递单号，单号的最大长度是32个字符</param>
        /// <param name="phone">收、寄件人的电话号码（手机和固定电话均可，只能填写一个，顺丰单号必填，其他快递公司选填。如座机号码有分机号，分机号无需上传。）</param>
        /// <returns></returns>
        public Task<SubscribeRespModel> SubscribeAsync(string orderCode, string company, string number, string phone)
        {
            var req = new Delivery100.SDK.Models.SubscribeReqModel
            {
                schema = "json",
                param = new MainParas()
                {
                    ordercode = orderCode,
                    company = company,
                    number = number,
                    phone = phone,
                    key = _deliveryOptions.Logisticskey,
                    parameters = new AdditionalParams()
                    {
                        callbackurl = _deliveryOptions.SubscribeCallbackUrl,
                        salt = _deliveryOptions.SignSalt,
                        resultv2 = "1",
                        autoCom = "1"
                    }
                }
            };

            try
            {
                var deliveryHttpClient = App.GetService<IDeliveryHttpClient>();
                return deliveryHttpClient.LogisticsAsync(req);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new SubscribeRespModel() { 
                    message = ex.Message,
                    returnCode = "500",
                    result = false
                });
            }
        }
    }
}
