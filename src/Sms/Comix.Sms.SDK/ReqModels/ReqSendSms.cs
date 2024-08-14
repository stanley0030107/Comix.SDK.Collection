using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.Sms.SDK.ReqModels
{
    public class ReqSendSms
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 短信内容
        /// </summary>
        public string Content { get; set; }
    }
}
