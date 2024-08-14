using Newtonsoft.Json;

namespace Comix.COS.Model.ReqModels
{
    public class CosStockRdduceReq
    {
        /// <summary>
        /// 客户号 
        /// </summary>
        [JsonProperty("customerCode")]
        public string CustomerCode { get; set; }
        /// <summary>
        /// 合约商品编码
        /// </summary>
        [JsonProperty("productCode")]
        public string ProductCode{ get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [JsonProperty("orderSn")]
        public string OrderSn{ get; set; }
        /// <summary>
        /// 扣减数量
        /// </summary>
        [JsonProperty("reduceNum")]
        public int ReduceNum{ get; set; }

    }
}