using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.SAP.SDK.Models
{
    public class POResponseDomain<T>
    {
        /// <summary>
        /// 系统名称
        /// </summary>
        public string SYSID { get; set; }
        /// <summary>
        /// 返回主体
        /// </summary>
        public T RESPONSE { get; set; }
        /// <summary>
        /// 请求状态 成功 or 失败
        /// </summary>
        public bool Success { get; set; } = false;
        /// <summary>
        /// 响应原始报文
        /// </summary>
        public string ResponseJson { get; set; } = "";
    }
}
