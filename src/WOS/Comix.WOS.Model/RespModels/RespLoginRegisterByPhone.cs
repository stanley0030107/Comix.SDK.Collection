using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.WOS.Model.RespModels
{
    /// <summary>
    /// 登录WOS 返回
    /// </summary>
    public class RespLoginRegisterByPhone
    {
        public string msg { get; set; }
        public int code { get; set; }
        public string token { get; set; }
    }

}
