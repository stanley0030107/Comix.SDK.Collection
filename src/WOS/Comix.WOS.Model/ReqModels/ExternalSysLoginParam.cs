using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.WOS.Model.ReqModels
{
    /// <summary>
    /// 外部系统登录WOS参数
    /// </summary>
    public class ExternalSysLoginParam: LoginRegisterByEmployeeIdParam
    {
        public ExternalSysLoginParam() { }

        /// <summary>
        /// 按钮授权
        /// </summary>
        [JsonProperty(propertyName: "permissions")]
        public List<string> Permissions { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        [JsonProperty(propertyName: "roles")]
        public List<RoleInfo> RoleCodes { get; set; }
    }

    /// <summary>
    /// 工单对应的角色
    /// </summary>
    public class RoleInfo
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        public string roleCode { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string roleName { get; set; }

        /// <summary>
        /// 数据权限
        /// </summary>
        public int dataScope { get; set; }
    }
}
