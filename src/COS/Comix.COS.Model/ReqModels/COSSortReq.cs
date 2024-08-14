using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.ReqModels
{
  public  class COSSortReq
    {
        /// <summary>
        /// 排序字段：createTime，updateTime
        /// </summary>
        [JsonProperty("field")]
        public string Field { get; set; }
        /// <summary>
        /// 排序方式,可用值:DEFAULT,ASC,DESC
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
