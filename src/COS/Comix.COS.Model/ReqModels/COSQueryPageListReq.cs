using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.ReqModels
{
    public class COSQueryPageListReq<T>
    {
        ///// <summary>
        ///// 当前页码	
        ///// </summary>
        //[JsonProperty("current")]
        //public int Current { get; set; }

        /// <summary>
        /// 分页数量	
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// 请求数据
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }  
    }
}
