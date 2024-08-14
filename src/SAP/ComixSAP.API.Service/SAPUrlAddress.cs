
using System;

namespace ComixSAP.API.Service
{
    /// <summary>
    /// SAP url 地址集合
    /// </summary>
    public class SAPUrlAddress
    {
        /// <summary>
        /// 创建/修改/删除/冻结客户主数据接口
        /// </summary>
        public const string CUSTOMER_MASTER_DATA_URL = "/RESTAdapter/data004_CustomerMasterDataOperation";
        /// <summary>
        /// 客户回款、费用报销接口
        /// </summary>
        public const string CREATE_SAP_VOU_URL = "/RESTAdapter/fico038_postFinancialDocuments";

        [Obsolete]
        public const string DEMO3 = "/RESTAdapter/demo3"; //弃用

        /// <summary>
        /// 查询客户信息
        /// </summary>
        public const string QUERY_SAP_VOU_URL = "/RESTAdapter/all013_Common_Data";

        /// <summary>
        /// 未清账客户查询
        /// </summary>
        [Obsolete]
        public const string ZCRM_READ_FBL5N_URL = "/RESTAdapter/fico039_readCustomerOpenItems"; //弃用

        /// <summary>
        /// CC产品分类描述表接口
        /// </summary>
        public const string ZDRP_INSERT_ZTPRODH_URL = "/RESTAdapter/data097_ProductDescription";

        /// <summary>
        /// 获取信控余额
        /// </summary>
        [Obsolete]
        public const string ZDRPBALANCE_URL = "/RESTAdapter/sd088_CustomerBalanceData"; //弃用

        /// <summary>
        /// 回款信息
        /// </summary>
        [Obsolete]
        public const string FICO099_RETURN_MONEY_URL = "/RESTAdapter/fico099_ReturnMoney"; //弃用
    }

   
}
