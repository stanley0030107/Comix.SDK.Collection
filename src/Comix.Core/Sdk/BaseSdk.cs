using Comix.Core.BaseModels;
using Microsoft.Extensions.Logging;

namespace Comix.Core.Sdk;

public class BaseSdk
{
    protected readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<BaseSdk> _logger;

    #region 基础方法

    public BaseSdk(IHttpClientFactory httpClientFactory,
        ILogger<BaseSdk> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    /// <summary>
    /// 执行post请求
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <param name="req"></param>
    /// <returns></returns>
    private async Task<ComixBaseResponseDto<T>> ExcuteAsync<T>(string url, string path, object req)
    {
        var resultStr = await ExcuteReturnStringAsync(url, path, req);
        var resultObj = JsonConvert.DeserializeObject<ComixBaseResponseDto<T>>(resultStr);
        return resultObj;
    }

    /// <summary>
    /// 执行post请求
    /// </summary>
    /// <param name="path"></param>
    /// <param name="req"></param>
    /// <returns>ComixBaseResponseDto 无body</returns>
    private async Task<ComixBaseResponseDto> ExcuteAsync(string url, string path, object req)
    {
        var resultStr = await ExcuteReturnStringAsync(url, path, req);
        var resultObj = JsonConvert.DeserializeObject<ComixBaseResponseDto>(resultStr);
        return resultObj;
    }

    /// <summary>
    /// 执行post请求
    /// </summary>
    /// <param name="path"></param>
    /// <param name="req"></param>
    /// <returns>ResponseHeader</returns>
    private async Task<ResponseHeader> ExcuteRetHeaderAsync(string url, string path, object req)
    {
        var resultStr = await ExcuteReturnStringAsync(url, path, req);
        var resultObj = JsonConvert.DeserializeObject<ResponseHeader>(resultStr);
        return resultObj;
    }

    /// <summary>
    /// 执行post请求
    /// </summary>
    /// <param name="path"></param>
    /// <param name="req"></param>
    /// <returns>Response Content.ReadAsString</returns>
    /// <exception cref="Exception"></exception>
    private async Task<string> ExcuteReturnStringAsync(string url, string path, object req)
    {
        //var jsonSettings = new JsonSerializerSettings
        //{
        //    DateFormatString = "yyyy-MM-ddThh:mm:ss.000Z"
        //};

        var jsonStr = JsonConvert.SerializeObject(req);

        if (url.EndsWith("/") && path.StartsWith("/"))
        {
            path = path.TrimStart('/');
        }

        url = $"{url}{path}";
        var jsonContent = new StringContent(jsonStr, System.Text.Encoding.UTF8, "application/json");
        var client = _httpClientFactory.CreateClient();

        var response = client.PostAsync(url, jsonContent).Result;
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"请求异常-{response.StatusCode}，请求url：{url}, 请求参数：{jsonStr}");
        }

        var resultStr = await response.Content.ReadAsStringAsync();
        _logger.LogInformation($"cdp请求：{url}\n请求参数：{jsonStr}\n响应参数：{resultStr}");
        return resultStr;
    }

    #endregion
}