using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.KuaiDi100.SDK.Models.Resp
{
    public class ReqAutoNumberDto
    {
        /// <summary>
        /// 单号长度
        /// </summary>
        public int lengthPre { get; set; }
        /// <summary>
        /// 快递公司对应的编码
        /// </summary>
        public string comCode { get; set; }
        /// <summary>
        /// 快递公司名称
        /// </summary>
        public string name { get; set; }
    }
}
