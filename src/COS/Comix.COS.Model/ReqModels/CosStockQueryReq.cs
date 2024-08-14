using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.ReqModels
{
    public class CosStockQueryReq
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
        public string ProductCode { get; set; }
    }



    public class RspCosQueryResult
    {
        /// <summary>
        /// 库存数量
        /// </summary>
        public string stockNum { get; set; }
        /// <summary>
        /// 合约商品编码
        /// </summary>
        public string productCode { get; set; }
        /// <summary>
        /// 客户号 
        /// </summary>
        public string customerCode { get; set; }
        /// <summary>
        /// 报错信息
        /// </summary>
        public string msg { get; set; }
    }
}
