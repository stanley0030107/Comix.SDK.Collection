using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComixSAP.Common.SAPPO.CCProductCategory
{
    /// <summary>
    /// 创建客户返回结果
    /// </summary>
    public class CCProductCategoryResponseBody
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MSGID { get; set; }
        /// <summary>
        /// 消息类型S-成功；E-失败
        /// </summary>
        public string MSGTY { get; set; }
        /// <summary>
        /// 消息的具体信息文本
        /// </summary>
        public string MSGTX { get; set; }

        /// <summary>
        /// 集团
        /// </summary>
        public int MANDT { get; set; }

        /// <summary>
        /// 同步日期
        /// </summary>
        public int ZTBRQ { get; set; }

        /// <summary>
        /// 同步时间
        /// </summary>
        public int ZTBSJ { get; set; }

        /// <summary>
        /// 交易返回码 
        /// </summary>
        public int EPTP { get; set; }

        /// <summary>
        /// 返回信息 
        /// </summary>
        public string EPMG { get; set; }

        /// <summary>
        /// 预留字段1 
        /// </summary>
        public string ZRSV01 { get; set; }
        /// <summary>
        /// 预留字段2
        /// </summary>
        public string ZRSV02 { get; set; }
        /// <summary>
        /// 预留字段3
        /// </summary>
        public string ZRSV03 { get; set; }
        /// <summary>
        /// 预留字段4
        /// </summary>
        public string ZRSV04 { get; set; }
        /// <summary>
        /// 预留字段5
        /// </summary>
        public string ZRSV05 { get; set; }
    }

   
   

}
