using Comix.Core.ElasticSearch;
using Comix.Core.Entity;
using Comix.Core.Util;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;
using Furion.LinqBuilder;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Comix.Core.Logging;

/// <summary>
/// ES日志写入器
/// </summary>
public class ElasticSearchLoggingWriter : IDatabaseLoggingWriter
{
    private readonly ElasticsearchClient _esClient;
    private readonly string indexName;
    private readonly bool _wechatEnable;
    private readonly string _robotKey;
    private readonly string application;
    private readonly HttpClient _httpClient;

    public ElasticSearchLoggingWriter(ElasticSearchFactory factory,
        IMemoryCache memoryCache,
        IHttpClientFactory httpClientFactory)
    {
        _esClient = factory.Get("Log");


        _wechatEnable = App.GetConfig<bool>("Logging:Wechat:Enabled");
        _robotKey = App.GetConfig<string>("Logging:Wechat:Key");
        _httpClient = httpClientFactory.CreateClient();

        indexName = App.GetConfig<string>("Logging:ElasticSearch:DefaultIndex");
        application = App.GetConfig<string>("Logging:ElasticSearch:Application");
    }

    public void Write(LogMessage logMsg, bool flush)
    {
        var document = new SysLogOp
        {
            LogName = logMsg.LogName,
            LogLevel = logMsg.LogLevel.ToString(),
            EventId = logMsg.EventId.Id.ToString(),
            Message = logMsg.Message,
            Exception = logMsg.Exception?.ToString(),
            LogDateTime = logMsg.LogDateTime,
            ThreadId = logMsg.ThreadId,
            TraceId = logMsg.TraceId,
            UseUtcTimestamp = logMsg.UseUtcTimestamp,
            Application = application
        };

        var currentIndexName = $"{indexName}-{DateTime.Now.ToString("yyyy-MM-dd")}";
        _esClient.Index(document, currentIndexName);

        WriteWechat(logMsg, flush);
    }

    public void WriteWechat(LogMessage logMsg, bool flush)
    {
        if (!_wechatEnable)
        {
            return;
        }

        if (_robotKey.IsNullOrEmpty())
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
异常信息：{logMsg.Exception}";
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

        var resp = _httpClient?
            .PostAsync($"https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={_robotKey}", stringContent)
            .Result;
        var respcontent = resp.Content.ReadAsStringAsync().Result;
    }

    public async Task WriteAsync(LogMessage logMsg, bool flush)
    {
        var document = new SysLogOp
        {
            LogName = logMsg.LogName,
            LogLevel = logMsg.LogLevel.ToString(),
            EventId = logMsg.EventId.Id.ToString(),
            Message = logMsg.Message,
            Exception = logMsg.Exception?.ToString(),
            LogDateTime = logMsg.LogDateTime,
            ThreadId = logMsg.ThreadId,
            TraceId = logMsg.TraceId,
            UseUtcTimestamp = logMsg.UseUtcTimestamp,
            Application = application
        };

        try
        {
            var currentIndexName = $"{indexName}-{DateTime.Now.ToString("yyyy-MM-dd")}";
            var response = _esClient.Index(document, currentIndexName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        WriteWechat(logMsg, flush);
    }
    
    public async Task WriteWechatAsync(LogMessage logMsg, bool flush)
    {
        if (!_wechatEnable)
        {
            return;
        }

        if (_robotKey.IsNullOrEmpty())
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
异常信息：{logMsg.Exception}";
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

        var resp = await _httpClient?
            .PostAsync($"https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={_robotKey}", stringContent);
        var respcontent = await resp.Content.ReadAsStringAsync();
    }
}