using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.OMS.SDK.Models
{
    public class OmsUrlAddress
    {
        /// <summary>
        /// 更新订单拆单状态
        /// </summary>
        public const string UpdateComposeStatusUrl = "/system/UpdateComposeStatus";

        public const string ProcessWebOrderForLinkSrv = "/system/ProcessWebOrderForLinkSrv";
        public const string ChangeLinkOrderStatusSrv = "/system/ChangeLinkOrderStatusSrv";
        public const string UniqueIdNewId = "/api/UniqueId/NewId";
    }
}
