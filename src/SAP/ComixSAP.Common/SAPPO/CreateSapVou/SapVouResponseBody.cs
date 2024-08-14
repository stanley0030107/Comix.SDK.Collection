using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComixSAP.Common.SAPPO.CreateSapVou
{
    /// <summary>
    /// 创建客户返回结果
    /// </summary>
    public class SapVouResponseBody
    {
        /// <summary>
        /// 
        /// </summary>
        public string MSGID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BUKRS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BELNR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int GJAHR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MSGTY { get; set; }
        /// <summary>
        /// 过账成功
        /// </summary>
        public string MSGTX { get; set; }

    }
}
