using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.Sms.SDK.Models
{
    public class SMSRoute
    {
        /// <summary>
        /// 获取token接口
        /// </summary>
        public static string getTokenUrl = "/sms/gettoken";
        /// <summary>
        /// 发送短信
        /// </summary>
        public static string sendSmsUrl = "/sms/send";
    }
}
