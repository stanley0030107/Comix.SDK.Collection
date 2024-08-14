using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComixSAP.Common.SAPPO.CCProductCategory
{
    /// <summary>
    /// 客户未清项查询接口 请求内容
    /// </summary>
    public class CCProductCategoryResquestBody
    {
      
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MSGID { get; set;} = "";
        /// <summary>
        /// 物料号  
        /// </summary>
        public string MATNR { get; set; } = "";

        /// <summary>
        /// 产品层次1
        /// </summary>
        public string PRODH1 { get; set; } = "";
        /// <summary>
        /// 描述
        /// </summary>
        public string VTEXT1 { get; set;} = "";
        /// <summary>
        /// 产品层次2
        /// </summary>
        public string PRODH2 { get; set;} = "";
        /// <summary>
        /// 描述
        /// </summary>
        public string VTEXT2 { get; set; } = "";

        /// <summary>
        /// 产品层次3
        /// </summary>
        public string PRODH3 { get; set; } = "";
        /// <summary>
        /// 长度为80的描述 
        /// </summary>
        public string VTEXT3 { get; set; } = "";

        /// <summary>
        /// 预留字段1
        /// </summary>
        public string ZRSV01 { get; set; } = "";
        /// <summary>
        /// 预留字段2
        /// </summary>
        public string ZRSV02 { get; set; } = "";

        /// <summary>
        /// 预留字段3
        /// </summary>
        public string ZRSV03 { get; set; } = "";
        /// <summary>
        /// 预留字段4
        /// </summary>
        public string ZRSV04 { get; set; } = "";

        /// <summary>
        /// 预留字段5
        /// </summary>
        public string ZRSV05 { get; set; } = "";
      

    }
  
}
