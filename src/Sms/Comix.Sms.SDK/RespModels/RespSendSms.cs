using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.Sms.SDK.RespModels
{
    public class RespSendSms
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        public string Desc { get; set; }
    }
}
