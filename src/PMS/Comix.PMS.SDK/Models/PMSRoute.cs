using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.PMS.SDK.Models
{
    public static class PMSRoute
    {
        /// <summary>
        /// PMS合同项目
        /// </summary>
        public static string ContractInfoPath = "/pms-edge-service/contract/complexPage/0/10";

        // <summary>
        /// 合同单条查询
        /// </summary>
        public static string ContractFindOnePath = "/pms-edge-service/contract/findOne";

        /// <summary>
        /// 项目查询
        /// </summary>
        public static string ProjectPath = "/pms-edge-service/project/complexPage/0/1";

        /// <summary>
        /// 获取PMS合同
        /// </summary>
        public static string ContractGetCustomerInfoPath = "/pms-edge-service/contract/getPMSCustomerContractInfo";
    }
}