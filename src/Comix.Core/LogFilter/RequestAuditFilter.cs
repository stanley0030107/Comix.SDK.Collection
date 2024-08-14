using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comix.Core.Entity;
using Comix.Core.Sqlsugar;
using Comix.Core.Util;
using Furion.DistributedIDGenerator;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Comix.Core.LogFilter
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    namespace Furion.Web.Core
    {
        public class RequestAuditFilter : IAsyncActionFilter
        {
            private readonly IDistributedIDGenerator _idGenerator;
            private readonly SqlSugarRepository<SysReqLog> _sysReqLogRepo;

            public RequestAuditFilter(IDistributedIDGenerator idGenerator,
                SqlSugarRepository<SysReqLog> sysReqLogRepo)
            {
                _idGenerator = idGenerator;
                _sysReqLogRepo = sysReqLogRepo;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                // 获取控制器、路由信息
                var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                // 获取请求的方法
                var method = actionDescriptor.MethodInfo;
                // 如果贴了 [SuppressMonitor] 特性则跳过
                if (method.IsDefined(typeof(SuppressMonitorAttribute), true)
                    || method.DeclaringType.IsDefined(typeof(SuppressMonitorAttribute), true))
                {
                    _ = await next();
                    return;
                }
                
                
                //============== 这里是执行方法之前获取数据 ====================

                // 获取 HttpContext 和 HttpRequest 对象
                var httpContext = context.HttpContext;
                var httpRequest = httpContext.Request;

                // 获取客户端 Ipv4 地址
                var remoteIPv4 = httpContext.GetRemoteIpAddressToIPv4();

                // 获取请求的 Url 地址
                var requestUrl = httpRequest.GetRequestUrlAddress();

                // 获取来源 Url 地址
                var refererUrl = httpRequest.GetRefererUrlAddress();

                // 获取请求参数（写入日志，需序列化成字符串后存储）
                var parameters = context.ActionArguments;

                // 获取操作人（必须授权访问才有值）"userId" 为你存储的 claims type，jwt 授权对应的是 payload 中存储的键名
                var userId = httpContext.User?.FindFirstValue("userId");

                // 请求时间
                var requestedTime = DateTime.Now;

                //============== 这里是执行方法之后获取数据 ====================
                var actionContext = await next();

                // 获取返回的结果
                var returnResult = actionContext.Result;

                // 判断是否请求成功，没有异常就是请求成功
                var isRequestSucceed = actionContext.Exception == null;

                // 获取调用堆栈信息，提供更加简单明了的调用和异常堆栈
                var stackTrace = EnhancedStackTrace.Current();

                var reqParams = JSON.Serialize(parameters);
                // 解析返回值
                var respParams = "";
                if (CheckVaildResult(actionContext.Result, out var data))
                {
                    respParams = data;
                }
                
                var log = new SysReqLog
                {
                    Id = (Guid)_idGenerator.Create(),
                    Direction = 1,
                    RequestHost = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                    RequestPort = context.HttpContext.Connection.RemotePort,
                    RequestUrl = requestUrl.SplitByLen(1024),
                    ReqParams = reqParams.SplitByLen(2048),
                    RequestTime = requestedTime,
                    ClassName = method.ReflectedType.FullName.SplitByLen(512),
                    Method = method.Name.SplitByLen(128),
                    UserId = userId.SplitByLen(64),
                    ResponseCode = context.HttpContext.Response.StatusCode,
                    ResponseTime = DateTime.Now,
                    RespParams = respParams.SplitByLen(2048)
                };
                SysLogJob.LogQueue.Enqueue(log);
            }

            /// <summary>
            /// 检查是否是有效的结果（可进行规范化的结果）
            /// </summary>
            /// <param name="result"></param>
            /// <param name="data"></param>
            /// <returns></returns>
            internal static bool CheckVaildResult(IActionResult result, out string data)
            {
                data = "";

                // 排除以下结果，跳过规范化处理
                var isDataResult = result switch
                {
                    ViewResult => false,
                    PartialViewResult => false,
                    FileResult => false,
                    ChallengeResult => false,
                    SignInResult => false,
                    SignOutResult => false,
                    RedirectToPageResult => false,
                    RedirectToRouteResult => false,
                    RedirectResult => false,
                    RedirectToActionResult => false,
                    LocalRedirectResult => false,
                    ForbidResult => false,
                    ViewComponentResult => false,
                    PageResult => false,
                    NotFoundResult => false,
                    NotFoundObjectResult => false,
                    _ => true,
                };

                // 目前支持返回值 ActionResult
                if (isDataResult)
                    data = result switch
                    {
                        // 处理内容结果
                        ContentResult content => content.Content,
                        // 处理对象结果
                        ObjectResult obj => JSON.Serialize( obj.Value),
                        // 处理 JSON 对象
                        JsonResult json => JSON.Serialize( json.Value),
                        _ => "",
                    };

                return isDataResult;
            }
        }
    }
}
