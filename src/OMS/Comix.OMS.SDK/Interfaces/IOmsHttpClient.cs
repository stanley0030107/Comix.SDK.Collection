using Comix.Core.LogFilter.Furion.Web.Core;
using Comix.OMS.SDK.Models;
using Furion.RemoteRequest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.OMS.SDK.Interfaces;

[Client(OmsSetup.OmsHttpClientName)]
[Obsolete(message: "在nuget引用包会无法注入远程调用，不建议使用，建议使用omsService的方法发起请求")]
public interface IOmsHttpClient : IHttpDispatchProxy//, IProcessWebOrderForLinkSrv
{
    /// <summary>
    /// 更新订单拆单状态
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    [Post(OmsUrlAddress.UpdateComposeStatusUrl)]
    [TypeFilter(typeof(RequestAuditFilter))]
    Task<ResponseBase<bool>> UpdateComposeStatusAsync(RequestBase<ComposeStatusBody> req);

    /// <summary>
    /// 推送订单到OMS
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    [Post(OmsUrlAddress.ProcessWebOrderForLinkSrv)]
    [TypeFilter(typeof(RequestAuditFilter))]
    Task<ResponseBase<ResponseProcessWebOrderBody>> ProcessWebOrderForLink(RequestBase<ProcessWebOrderForLinkBody> req);

    /// <summary>
    /// 修改订单状态
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    [Post(OmsUrlAddress.ChangeLinkOrderStatusSrv)]
    [TypeFilter(typeof(RequestAuditFilter))]
    Task<ResponseBase<ResponseChangeLinkOrderStatusBody>> ChangeLinkOrderStatus(RequestBase<ChangeLinkOrderStatusBody> req);

    /// <summary>
    /// 获取订单号
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    [Post(OmsUrlAddress.UniqueIdNewId)]
    [TypeFilter(typeof(RequestAuditFilter))]
    Task<ResponseForComModel> UniqueIdNewId(CodeParam req);
}