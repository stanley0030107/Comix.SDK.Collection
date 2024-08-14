using Comix.Core.LogFilter.Furion.Web.Core;
using Comix.OMS.SDK.Models;
using Furion.RemoteRequest;
using Microsoft.AspNetCore.Mvc;

namespace Comix.OMS.SDK.Interfaces;

public interface IProcessWebOrderForLinkSrv
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