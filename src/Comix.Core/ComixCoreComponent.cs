using Comix.Core.Cache;
using Comix.Core.EventBus;
using Comix.Core.Logging;
using Comix.Core.Option;
using System.Net.Mail;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using Comix.Core.ElasticSearch;
using Yitter.IdGenerator;
using Microsoft.Extensions.Logging;
using Comix.Core.LogFilter;
using Comix.Core.LogFilter.Furion.Web.Core;
using Comix.Core.Util;
using Aliyun.OSS;
using OnceMi.AspNetCore.OSS;

namespace Comix.Core;

/// <summary>
/// 注入基础组件
/// 
/// 全部项目都要用到的
/// </summary>
public class ComixCoreComponent : IServiceComponent
{
    public void Load(IServiceCollection services, ComponentContext componentContext)
    {
        // 配置选项
        services.AddProjectOptions();

        // 缓存注册
        services.AddCache();

        // 远程请求
        services.AddRemoteRequest();

        // 控制台格式化
        services.AddConsoleFormatter(options =>
        {
            options.DateFormat = "yyyy-MM-dd HH:mm:ss(zzz) dddd";
        });

        // 日志监听
        services.AddMonitorLogging(options =>
        {
            options.IgnorePropertyNames = new[] { "Byte" };
            options.IgnorePropertyTypes = new[] { typeof(byte[]) };
        });

        // ElasticSearch
        services
            .AddElasticSearch()
            .AddElasticSearchLog();

        // 事件总线
        services.AddEventBus(options =>
        {
            options.UseUtcTimestamp = false;
            // 不启用事件日志
            options.LogEnabled = false;
            // 事件执行器（失败重试）
            options.AddExecutor<RetryEventHandlerExecutor>();
            //// 替换事件源存储器
            //options.ReplaceStorer(serviceProvider =>
            //{
            //    var redisClient = serviceProvider.GetService<ICache>();
            //    return new RedisEventSourceStorer(redisClient);
            //});
        });

        // 电子邮件
        var emailOpt = App.GetOptions<EmailOptions>();
        services.AddFluentEmail(emailOpt.DefaultFromEmail, emailOpt.DefaultFromName)
            .AddSmtpSender(new SmtpClient(emailOpt.Host, emailOpt.Port)
            {
                EnableSsl = emailOpt.EnableSsl,
                UseDefaultCredentials = emailOpt.UseDefaultCredentials,
                Credentials = new NetworkCredential(emailOpt.UserName, emailOpt.Password)
            });

        // 日志记录
        services.AddHostedService<SysLogJob>();
        if (App.GetConfig<bool>("Logging:File:Enabled")) // 日志写入文件
        {
            Array.ForEach(new[] { LogLevel.Information, LogLevel.Warning, LogLevel.Error }, logLevel =>
            {
                services.AddFileLogging(options =>
                {
                    options.FileNameRule = fileName => string.Format(fileName, DateTime.Now, logLevel.ToString()); // 每天创建一个文件
                    options.WriteFilter = logMsg => logMsg.LogLevel == logLevel; // 日志级别
                    options.HandleWriteError = (writeError) => // 写入失败时启用备用文件
                    {
                        writeError.UseRollbackFileName(Path.GetFileNameWithoutExtension(writeError.CurrentFileName) + "-oops" + Path.GetExtension(writeError.CurrentFileName));
                    };
                });
            });
        }
        if (App.GetConfig<bool>("Logging:Database:Enabled")) // 日志写入数据库
        {
            services.AddDatabaseLogging<DatabaseLoggingWriter>();
        }

        // if (App.GetConfig<bool>("Logging:Wechat:Enabled")) // 日志写入企微
        // {
        //     services.AddDatabaseLogging<WechatLoggingWriter>(options =>
        //     {
        //         options.WriteFilter = (logMsg) => { return logMsg.LogLevel == LogLevel.Error; };
        //         options.MessageFormat = log => log.Message;
        //         options.IgnoreReferenceLoop = false;
        //     });
        // }
        if (App.GetConfig<bool>("Logging:ElasticSearch:Enabled")) // 日志写入ElasticSearch
        {
            services.AddDatabaseLogging<ElasticSearchLoggingWriter>(options =>
            {
                options.MessageFormat = log => log.Message;
                options.IgnoreReferenceLoop = false;
            });
        }


        // 配置雪花Id算法机器码
        YitIdHelper.SetIdGenerator(new IdGeneratorOptions
        {
            WorkerId = App.GetOptions<SnowIdOptions>().WorkerId
        });
            
        services.AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            // options.JsonSerializerOptions.DictionaryKeyPolicy = null;    // 配置 Dictionary 类型序列化输出
            options.JsonSerializerOptions.Converters.AddDateTimeTypeConverters("yyyy-MM-dd HH:mm:ss", true);
        });

        services.AddMvcFilter<RequestAuditFilter>();

        services.AddScoped<CodeGenerater>();

        //OSS对象存储,配置文件中加载节点为‘OSSProvider’的配置信息
        var ossOpt = App.GetConfig<OSSProviderOptions>("OSSProvider", true);
        if (ossOpt != null)
        {
            services.AddOSSService(System.Enum.GetName(ossOpt.Provider), "OSSProvider");
        }
                
    }
}