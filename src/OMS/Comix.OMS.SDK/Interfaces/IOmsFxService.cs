using Comix.OMS.SDK.Models;
using Furion.DependencyInjection;

namespace Comix.OMS.SDK.Interfaces;

public interface IOmsFxService : IScoped
{
    #region 基础方法

    /// <summary>
    /// 执行post请求
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <param name="req"></param>
    /// <returns></returns>
    Task<ResponseBase<T>> ExecuteAsync<T>(string path, object req) where T : new();

    /// <summary>
    /// 执行post请求
    /// </summary>
    /// <param name="path"></param>
    /// <param name="req"></param>
    /// <returns>ComixBaseResponseDto 无body</returns>
    Task<ResponseBase> ExecuteAsync(string path, object req);

    /// <summary>
    /// 执行post请求
    /// </summary>
    /// <param name="path"></param>
    /// <param name="req"></param>
    /// <returns>ResponseHeader</returns>
    Task<ResponseBase> ExecuteRetHeaderAsync(string path, object req);

    /// <summary>
    /// 执行post请求
    /// </summary>
    /// <param name="path"></param>
    /// <param name="req"></param>
    /// <returns>Response Content.ReadAsString</returns>
    /// <exception cref="Exception"></exception>
    Task<string> ExecuteReturnStringAsync(string path, object req);

    #endregion

}