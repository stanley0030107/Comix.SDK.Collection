using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.RespModels
{
    public class COSResp<T>
    {
        /// <summary>
        /// 请求是否成功	
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// 业务code码	
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 接口提示信息	
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 链路Id	
        /// </summary>
        public string traceId { get; set; }

        /// <summary>
        /// 结果数据
        /// </summary>
        public T data { get; set; } = default(T);
    }
}
