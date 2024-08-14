using Comix.Core.LogFilter.Furion.Web.Core;
using Comix.OMS.SDK.Models;
using Furion.RemoteRequest;
using Microsoft.AspNetCore.Mvc;

namespace Comix.OMS.SDK.Interfaces;

[Client(OmsSetup.OmsFxHttpClientName)]
[Obsolete(message: "在nuget引用包会无法注入远程调用，不建议使用，建议使用omsService的方法发起请求")]
public interface IOmsFxHttpClient: IHttpDispatchProxy//, IProcessWebOrderForLinkSrv
{

    /// <summary>
    /// 推送订单到OMS
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    [Post(OmsUrlAddress.ProcessWebOrderForLinkSrv)]
    [TypeFilter(typeof(RequestAuditFilter))]
    Task<ResponseBase<ResponseProcessWebOrderBody>> ProcessWebOrderForLink(RequestBase<ProcessWebOrderForLinkBody> req);
}