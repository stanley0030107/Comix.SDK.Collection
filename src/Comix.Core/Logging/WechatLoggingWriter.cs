using Furion.LinqBuilder;
using Microsoft.Extensions.Logging;

namespace Comix.Core.Logging;

public class WechatLoggingWriter : IDatabaseLoggingWriter
{
    private readonly HttpClient httpClient;
    public string robotKey { get; set; }
    public bool enable { get; set; }

    public WechatLoggingWriter(IHttpClientFactory httpClientFactory)
    {
        enable = App.GetConfig<bool>("Logging:Wechat:Enabled");
        robotKey = App.GetConfig<string>("Logging:Wechat:Key");
        httpClient = httpClientFactory.CreateClient();
    }

    public void Write(LogMessage logMsg, bool flush)
    {
        if (!enable)
        {
            return;
        }

        if (robotKey.IsNullOrEmpty())
        {
            return;
        }

        if (logMsg.LogLevel != LogLevel.Error)
        {
            return;
        }
        
        var log = @$"应用名称：{AppDomain.CurrentDomain.FriendlyName}
日志级别：{logMsg.LogLevel.ToString()}
日志消息：{logMsg.Message}
异常信息：{logMsg.Exception?.ToString()}";
        var mentionedMobileList = new List<string>() { "@all" };
        var msg = new
        {
            mentioned_mobile_list = mentionedMobileList,
            msgtype = "markdown",
            markdown = new
            {
                content = log
            }
        };
        var stringContent = new StringContent(JsonConvert.SerializeObject(msg), Encoding.UTF8, "application/json");
        
        var resp = httpClient?
            .PostAsync($"https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={robotKey}", stringContent)
            .Result;
        var respcontent = resp.Content.ReadAsStringAsync().Result;
    }

    public async Task WriteAsync(LogMessage logMsg, bool flush)
    {
        if (!enable)
        {
            return;
        }

        if (robotKey.IsNullOrEmpty())
        {
            return;
        }

        if (logMsg.LogLevel != LogLevel.Error)
        {
            return;
        }
        
        var log = @$"应用名称：{AppDomain.CurrentDomain.FriendlyName}
日志级别：{logMsg.LogLevel.ToString()}
日志消息：{logMsg.Message}
异常信息：{logMsg.Exception?.ToString()}";
        var mentionedMobileList = new List<string>() { "@all" };
        var msg = new
        {
            mentioned_mobile_list = mentionedMobileList,
            msgtype = "markdown",
            markdown = new
            {
                content = log
            }
        };
        var stringContent = new StringContent(JsonConvert.SerializeObject(msg), Encoding.UTF8, "application/json");
        
        var resp = await httpClient?
            .PostAsync($"https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={robotKey}", stringContent);
        var respcontent = await resp.Content.ReadAsStringAsync();
    }
}