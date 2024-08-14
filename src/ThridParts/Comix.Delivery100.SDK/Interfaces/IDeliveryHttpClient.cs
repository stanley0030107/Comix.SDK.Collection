using Comix.Delivery100.SDK.Models;
using Furion.RemoteRequest;

namespace Comix.Delivery100.SDK.Interfaces
{
    [Client(DeliverySetup.DeliveryHttpClientName)]
    public interface IDeliveryHttpClient : IHttpDispatchProxy
    {
        /// <summary>
        /// Subscribe
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [Post(DeliveryUrlAddress.LogisticsUrl)]
        Task<SubscribeRespModel> LogisticsAsync([Body("application/json", "UTF-8")] SubscribeReqModel req);
    }
}
