using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.RPA.SDK.Output
{
    public class RpaBaseOutput<T>
    {
        /// <summary>
        /// 状态码：200=成功
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 业务数据
        /// </summary>
        public T data { get; set; } 
    }
    public class RpaBaseOutput
    {
        /// <summary>
        /// 状态码：200=成功
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string message { get; set; }
    }
}
