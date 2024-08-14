using Comix.SAP.SDK.Models;
using Furion.RemoteRequest;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Comix.Core.LogFilter.Furion.Web.Core;

namespace Comix.SAP.SDK.Interfaces
{
    [Client(SapSetup.SapHttpClientName)]
    public interface ISapHttpClient : IHttpDispatchProxy
    {
        /// <summary>
        /// 客户回款、费用报销接口
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [Post(SAPUrlAddress.CREATE_SAP_VOU_URL)]
        //[TypeFilter(typeof(RequestAuditFilter))]
        Task<POResponseDomain<List<SapVouResponseBody>>> CreateSapVouAsync([Body]
            PORequestDomain<List<SapVouResquestBody>> req);

        /// <summary>
        /// 查询SAP客编，根据客户名称
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [Post(SAPUrlAddress.CUSTOMER_MASTER_QUERY_URL)]
        Task<POResponseDomain<List<RespCustomerMasterQueryBody>>> CustomerMasterQueryAsync([Body]
            PORequestDomain<ReqCustomerMasterQueryBody> req);
    }
}
