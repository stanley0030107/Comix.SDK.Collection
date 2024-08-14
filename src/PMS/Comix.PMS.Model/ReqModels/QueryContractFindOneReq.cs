using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.PMS.Model.ReqModels
{
    /// <summary>
    /// 合同单条查询请求参数
    /// </summary>
    public class QueryContractFindOneReq
    {
        /// <summary>
        /// 集采项目编码
        /// </summary>
        public string projectCode { get; set; }
        /// <summary>
        /// 合同有效期筛选
        /// </summary>
        public bool isExpire { get; set; }
        /// <summary>
        /// 是否查找最高支付方式天数
        /// </summary>
        public bool isFindMaxPayConditionDays { get; set; }
        /// <summary>
        /// 是否查询合同履约,默认false
        /// </summary>
        public bool statementQuery { get; set; }
        /// <summary>
        /// 是否查询合同区划,默认false
        /// </summary>
        public bool districtsQuery { get; set; }
        /// <summary>
        /// 是否查询合同联系人,默认false
        /// </summary>
        public bool contactsQuery { get; set; }
        /// <summary>
        /// 是否查询合同关联子公司,默认false
        /// </summary>
        public bool companiesQuery { get; set; }
        /// <summary>
        /// 是否查询合同品类,默认false
        /// </summary>
        public bool categoriesQuery { get; set; }
        /// <summary>
        /// 是否查询合同审核日志,默认false
        /// </summary>
        public bool auditLogsQuery { get; set; }
        /// <summary>
        /// 是否查询合同附件信息,默认false
        /// </summary>
        public bool attachmentsQuery { get; set; }
        /// <summary>
        /// 是否查询合同绑定区域,默认false
        /// </summary>
        public bool areasQuery { get; set; }
    }
}
