using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.SAP.SDK.Models
{
    /// <summary>
    /// SAP url 地址集合
    /// </summary>
    public class SAPUrlAddress
    {
        /// <summary>
        /// 创建/修改/删除/冻结客户主数据接口
        /// </summary>
        public const string CUSTOMER_MASTER_DATA_URL = "RESTAdapter/data004_CustomerMasterDataOperation";
        /// <summary>
        /// 客户回款、费用报销接口
        /// </summary>
        public const string CREATE_SAP_VOU_URL = "RESTAdapter/fico038_postFinancialDocuments";

        /// <summary>
        /// 查询客户信息
        /// </summary>
        public const string QUERY_SAP_VOU_URL = "RESTAdapter/all013_Common_Data";

        /// <summary>
        /// 查询客户信息-新
        /// 2024-5-20
        /// </summary>
        public const string CUSTOMER_MASTER_QUERY_URL = "RESTAdapter/data112_CustomerMasterQuery";

        /// <summary>
        /// CC产品分类描述表接口
        /// </summary>
        public const string ZDRP_INSERT_ZTPRODH_URL = "RESTAdapter/data097_ProductDescription";


    }
}
