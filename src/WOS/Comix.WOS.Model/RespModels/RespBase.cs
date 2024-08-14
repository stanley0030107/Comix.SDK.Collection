using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.WOS.Model.RespModels
{
    /// <summary>
    /// 返回基类
    /// </summary>
    public class RespBase<T>
    {
        public RespBase() { }

        public bool success { get; set; }

        public string code { get; set; }

        public string msg { get; set; }

        public string traceId { get; set; }

        public T data { get; set; }
    }
}
