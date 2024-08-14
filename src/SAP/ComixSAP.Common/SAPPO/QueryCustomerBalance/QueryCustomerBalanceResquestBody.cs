using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComixSAP.Common.SAPPO.QueryCustomerBalance
{
    /// <summary>
    /// 客户未清项查询接口 请求内容
    /// </summary>
    public class QueryCustomerBalanceResquestBody
    {
      
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MSGID { get; set;} = "";
        /// <summary>
        /// 关键日期中的未清项 
        /// </summary>
        public string ALLGSTID { get; set; } = "";
        /// <summary>
        /// 客户编号
        /// </summary>
        public string KUNNR { get; set;} = "";
        /// <summary>
        /// 要求注释项目
        /// </summary>
        public string NOTEDITEMS { get; set;} = "";

        /// <summary>
        /// 查询条件
        /// </summary>
        public List<QueryCustomerBalanceResquestItem> IT_BSID { get; set; }

    }
    /// <summary>
    /// 查询条件
    /// </summary>
    public class QueryCustomerBalanceResquestItem
    {
        /// <summary>
        /// 分销渠道
        /// </summary>
        public string VTWEG { get; set; } = "";
        /// <summary>
        /// 公司代码
        /// </summary>
        public string BUKRS { get; set; } = "";
        /// <summary>
        /// 总分类帐帐目
        /// </summary>
        public string HKONT { get; set; } = "";

    }
}
