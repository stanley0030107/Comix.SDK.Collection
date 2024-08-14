using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.WOS.Model.ReqModels
{
    /// <summary>
    /// 登录WOS 请求参数
    /// </summary>
    public class LoginRegisterByPhoneParam
    {
        [JsonProperty(propertyName: "phonenumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty(propertyName: "credential")]
        public string Credential { get; set; }
    }

}
