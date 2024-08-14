using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.PMS.Model.ReqModels
{
    /// <summary>
    /// 请求PMS合同项目接口参数
    /// </summary>
    public class ProjectParam
    {
        /// <summary>
        /// 集采项目编号
        /// </summary>
        [JsonProperty(propertyName: "projectCode")]
        public string ProjectCode { get; set; }     
    }
}
