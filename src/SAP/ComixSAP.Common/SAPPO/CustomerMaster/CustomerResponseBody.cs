using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComixSAP.Common.SAPPO.CustomerMaster
{
    /// <summary>
    /// 创建客户返回结果
    /// </summary>
    public class CustomerResponseBody
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MSGID { get; set; }
        /// <summary>
        /// 客户编码
        /// </summary>
        public string KUNNR { get; set; }
        /// <summary>
        /// 名称1
        /// </summary>
        public string NAME1 { get; set; }
        /// <summary>
        /// 消息类型S-成功；E-失败
        /// </summary>
        public string MSGTY { get; set; }
        /// <summary>
        /// 消息的具体信息文本
        /// </summary>
        public string MSGTX { get; set; }
    }
}
