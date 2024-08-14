using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.KuaiDi100.SDK.Models.Resp
{
    public class RespAddressParseDto
    {
        /// <summary>
        /// 详细地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string[] mobile { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 输入的内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 明细
        /// </summary>
        public RespAddressParseDetail xzq { get; set; }
    }

    public class RespAddressParseDetail
    {
        /// <summary>
        /// 市编码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 层级
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// 区县
        /// </summary>
        public string district { get; set; }
        /// <summary>
        /// 区县编码
        /// </summary>
        public string pCode { get; set; }
        /// <summary>
        /// 省市区
        /// </summary>
        public string fullName { get; set; }
        /// <summary>
        /// 详情地址
        /// </summary>
        public string subArea { get; set; }
    }
}
