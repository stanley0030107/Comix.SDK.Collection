using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.WOS.Model.ReqModels
{
    /// <summary>
    /// 员工工号登录WOS
    /// </summary>
    public class LoginRegisterByEmployeeIdParam
    {
        /// <summary>
        /// 工号
        /// </summary>
        [JsonProperty(propertyName: "employeeNo")]
        public string EmployeeNo { get; set; }

        /// <summary>
        /// 秘钥
        /// </summary>
        [JsonProperty(propertyName: "credential")]
        public string Credential { get; set; }
    }
}
