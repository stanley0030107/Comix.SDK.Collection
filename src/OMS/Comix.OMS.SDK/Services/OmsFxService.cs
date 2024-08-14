using System.Data;
using Comix.Core.Sqlsugar;
using Comix.OMS.SDK.Interfaces;
using Comix.OMS.SDK.Models;
using Furion;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OMSModels;
using SqlSugar;

namespace Comix.OMS.SDK.Services;

public class OmsFxService : IOmsFxService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<OmsFxService> _logger;
    private readonly SqlSugarScope _db;
    private readonly OmsOptions _omsOptions;

    public OmsFxService(ISqlSugarClient db,
        IHttpClientFactory httpClientFactory,
        ILogger<OmsFxService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _db = db as SqlSugarScope;
        _omsOptions = App.GetOptions<OmsOptions>();
    }


    #region 基础方法

    /// <summary>
    /// 执行post请求
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <param name="req"></param>
    /// <returns></returns>
    public async Task<ResponseBase<T>> ExecuteAsync<T>(string path, object req) where T : new()    
    {
        var resultStr = await ExecuteReturnStringAsync(path, req);
        var resultObj = JsonConvert.DeserializeObject<ResponseBase<T>>(resultStr);
        return resultObj;
    }

    /// <summary>
    /// 执行post请求
    /// </summary>
    /// <param name="path"></param>
    /// <param name="req"></param>
    /// <returns>ComixBaseResponseDto 无body</returns>
    public async Task<ResponseBase> ExecuteAsync(string path, object req)
    {
        var resultStr = await ExecuteReturnStringAsync(path, req);
        var resultObj = JsonConvert.DeserializeObject<ResponseBase>(resultStr);
        return resultObj;
    }

    /// <summary>
    /// 执行post请求
    /// </summary>
    /// <param name="path"></param>
    /// <param name="req"></param>
    /// <returns>ResponseHeader</returns>
    public async Task<ResponseBase> ExecuteRetHeaderAsync(string path, object req)
    {
        var resultStr = await ExecuteReturnStringAsync(path, req);
        var resultObj = JsonConvert.DeserializeObject<ResponseBase>(resultStr);
        return resultObj;
    }

    /// <summary>
    /// 执行post请求
    /// </summary>
    /// <param name="path"></param>
    /// <param name="req"></param>
    /// <returns>Response Content.ReadAsString</returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> ExecuteReturnStringAsync(string path, object req)
    {
        var jsonStr = JsonConvert.SerializeObject(req);

        if (_omsOptions.FxUrl.EndsWith("/") && path.StartsWith("/"))
        {
            path = path.TrimStart('/');
        }

        var url = $"{_omsOptions.FxUrl}{path}";

        var jsonContent = new StringContent(jsonStr, System.Text.Encoding.UTF8, "application/json");
        var client = _httpClientFactory.CreateClient();

        var response = client.PostAsync(url, jsonContent).Result;
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"请求异常-{response.StatusCode}，请求url：{url}, 请求参数：{jsonStr}");
        }

        var resultStr = await response.Content.ReadAsStringAsync();

        _logger.LogInformation("oms请求：{Url}\\n请求参数：{JsonStr}\\n响应参数：{ResultStr}", url, jsonStr, resultStr);

        return resultStr;
    }

    #endregion
}