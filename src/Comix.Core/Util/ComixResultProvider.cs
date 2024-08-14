using Comix.Core.BaseModels;

namespace Comix.Core.Util;

/// <summary>
/// 全局规范化结果
/// </summary>
[UnifyModel(typeof(ComixBaseResponseDto<>))]
public class ComixResultProvider : IUnifyResultProvider
{
    public IActionResult OnAuthorizeException(DefaultHttpContext context, ExceptionMetadata metadata)
    {
        return new JsonResult(RESTfulResult(metadata.StatusCode, data: metadata.Data, errors: metadata.Errors));
    }

    /// <summary>
    /// 异常返回值
    /// </summary>
    /// <param name="context"></param>
    /// <param name="metadata"></param>
    /// <returns></returns>
    public IActionResult OnException(ExceptionContext context, ExceptionMetadata metadata)
    {
        return new JsonResult(RESTfulResult(metadata.StatusCode, data: metadata.Data, errors: metadata.Errors));
    }

    /// <summary>
    /// 成功返回值
    /// </summary>
    /// <param name="context"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public IActionResult OnSucceeded(ActionExecutedContext context, object data)
    {
        if (data is ComixBaseResponseDto)
        {
            return new JsonResult(data);
        }
        return new JsonResult(RESTfulResult(StatusCodes.Status200OK, true, data));
    }

    /// <summary>
    /// 验证失败返回值
    /// </summary>
    /// <param name="context"></param>
    /// <param name="metadata"></param>
    /// <returns></returns>
    public IActionResult OnValidateFailed(ActionExecutingContext context, ValidationMetadata metadata)
    {
        return new JsonResult(RESTfulResult(metadata.StatusCode ?? StatusCodes.Status400BadRequest, data: metadata.Data, errors: metadata.ValidationResult));
    }

    /// <summary>
    /// 特定状态码返回值
    /// </summary>
    /// <param name="context"></param>
    /// <param name="statusCode"></param>
    /// <param name="unifyResultSettings"></param>
    /// <returns></returns>
    public async Task OnResponseStatusCodes(HttpContext context, int statusCode, UnifyResultSettingsOptions unifyResultSettings)
    {
        // 设置响应状态码
        UnifyContext.SetResponseStatusCodes(context, statusCode, unifyResultSettings);

        switch (statusCode)
        {
            // 处理 401 状态码
            case StatusCodes.Status401Unauthorized:
                await context.Response.WriteAsJsonAsync(RESTfulResult<object>(statusCode, errors: "401 登录已过期，请重新登录"),
                    App.GetOptions<JsonOptions>()?.JsonSerializerOptions);
                break;
            // 处理 403 状态码
            case StatusCodes.Status403Forbidden:
                await context.Response.WriteAsJsonAsync(RESTfulResult<object>(statusCode, errors: "403 禁止访问，没有权限"),
                    App.GetOptions<JsonOptions>()?.JsonSerializerOptions);
                break;

            default: break;
        }
    }

    /// <summary>
    /// 返回 RESTful 风格结果集
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="succeeded"></param>
    /// <param name="data"></param>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static ComixBaseResponseDto<T> RESTfulResult<T>
        (int statusCode, bool succeeded = default, T data = default, object errors = default)
    {
        return new ComixBaseResponseDto<T>
        {
            MsgHeader = new ResponseHeader
            {
                RetCode = succeeded ? "Y" : "N",
                RetErrCode = statusCode.ToString(),
                RetMessage = errors == null || errors is string ? (string)errors : JSON.Serialize(errors)
            },
            MsgBody = data
        };
    }
    
    /// <summary>
    /// 返回 RESTful 风格结果集
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="succeeded"></param>
    /// <param name="data"></param>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static ComixBaseResponseDto RESTfulResult
        (int statusCode, bool succeeded = default, object errors = default)
    {
        return new ComixBaseResponseDto
        {
            MsgHeader = new ResponseHeader
            {
                RetCode = succeeded ? "Y" : "N",
                RetErrCode = statusCode.ToString(),
                RetMessage = errors is string str ? str : JSON.Serialize(errors)
            }
        };
    }

    public static ComixBaseResponseDto<T> Successed<T>(T data = default, string msg = null)
    {
        return RESTfulResult<T>(StatusCodes.Status200OK, true, data, msg);
    }
    public static ComixBaseResponseDto Successed(string msg = null)
    {
        return RESTfulResult(StatusCodes.Status200OK, true, errors: msg);
    }

    public static ComixBaseResponseDto Fail(int? statusCode, string msg = null)
    {
        return RESTfulResult(statusCode.HasValue ? statusCode.Value : StatusCodes.Status500InternalServerError, false, errors: msg);
    }
    public static ComixBaseResponseDto Fail(string msg = null)
    {
        return RESTfulResult(StatusCodes.Status500InternalServerError, false, errors: msg);
    }

    public static ComixBaseResponseDto<T> Fail<T>(int? statusCode, string msg = null, T data = default)
    {
        return RESTfulResult<T>(statusCode.HasValue ? statusCode.Value : StatusCodes.Status500InternalServerError, false, data, msg);
    }
    public static ComixBaseResponseDto<T> Fail<T>(string msg = null, T data = default)
    {
        return RESTfulResult<T>(StatusCodes.Status500InternalServerError, false, data, msg);
    }
}