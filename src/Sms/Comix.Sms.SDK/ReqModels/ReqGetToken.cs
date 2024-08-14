using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.Sms.SDK.ReqModels
{
    public class ReqGetToken
    {
        /// <summary>
        /// 应用编号
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// 应用密钥
        /// </summary>
        public string AppSercet { get; set; }
    }
}
