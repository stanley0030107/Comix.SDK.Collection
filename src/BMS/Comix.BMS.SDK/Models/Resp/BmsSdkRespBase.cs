using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.BMS.SDK.Models.Resp
{
    public class BmsSdkRespBase
    {
        /// <summary>
        /// 业务编码：200=成功
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string message { get; set; }

        public string traceId { get; set; }
    }

    public class BmsSdkRespBase<T>
    {
        /// <summary>
        /// 业务编码：200=成功
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 业务实体
        /// </summary>
        public T result { get; set; }

        public string traceId { get; set; }
    }
}
