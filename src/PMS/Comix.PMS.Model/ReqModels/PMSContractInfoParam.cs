using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.PMS.Model.ReqModels
{
    /// <summary>
    /// 请求PMS合同项目接口参数
    /// </summary>
    public class PMSContractInfoParam
    {
        /// <summary>
        /// 集采项目编号
        /// </summary>
        [JsonProperty(propertyName: "projectCode")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [JsonProperty(propertyName: "contractProjectCode")]
        public string ContractProjectCode { get; set; }

        /// <summary>
        /// 是否查询合同区划
        /// </summary>
        [JsonProperty(propertyName: "districtsQuery")]
        public bool DistrictsQuery { get; set; } 
    }

}
