using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.WOS.SDK.Models
{
    public static class WOSRoute
    {
        /// <summary>
        /// 登录WOS
        /// </summary>
        public static string LoginRegisterByPhonePath = "/wos-admin/loginRegisterByPhone";

        /// <summary>
        /// 登录WOS
        /// </summary>
        public static string LoginRegisterByEmployeeNoPath = "/wos-admin/employeeLogin";

        /// <summary>
        /// 外部系统登录WOS 带角色权限
        /// </summary>
        public static string ExternalSysLoginPath = "/wos-admin/externalSysLogin";

        /// <summary>
        /// 请求发起工单
        /// </summary>
        public static string WorkOrderPreOrderPath = "/wos-admin/workOrder/preOrder";

        /// <summary>
        /// 客诉统计待办
        /// </summary>
        public static string ComplaintsStatistics = "/wos-admin/complaints/statistics";

        /// <summary>
        /// 改单统计待办
        /// </summary>
        public static string ChangeOrderStatistics = "/wos-admin/changeOrder/statistics";

        /// <summary>
        /// 获取待评价数量
        /// </summary>
        public static string CommentOrderStatistics = "/wos-admin/workOrder/toBeEvaluated";

        /// <summary>
        /// 批量创建工单
        /// </summary>
        public static string WorkOrderBatchSavePath = "/wos-admin/workOrder/batchSave";
    }
}