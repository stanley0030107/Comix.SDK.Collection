using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.Sms.SDK.RespModels
{
    public class RespGetToken
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpirationTime { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        public string Desc { get; set; }
    }
}
