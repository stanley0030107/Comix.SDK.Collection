using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.KuaiDi100.SDK.Models.Resp
{
    public class RespBase<T>
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
    public class RespBase
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
