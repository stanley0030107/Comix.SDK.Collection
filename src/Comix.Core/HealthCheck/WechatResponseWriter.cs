using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json.Linq;

namespace Comix.Core.HealthCheck;

public class WechatResponseWriter
{
            public static string key;

        public static Task WriteHealthCheckWechatResponse(HttpContext context, HealthReport result)
        {
            if (result.Status == HealthStatus.Healthy)
            {
                return context.Response.WriteAsync(
                   "Healthy");
            }
            else if (result.Status == HealthStatus.Degraded)
            {
                return context.Response.WriteAsync(
                   "Degraded");
            }
            else
            {
                if (!string.IsNullOrEmpty(key))
                {
                    var json = new JObject(
    new JProperty("status", result.Status.ToString()),
    new JProperty("results", new JObject(result.Entries.Select(pair =>
    new JProperty(pair.Key, new JObject(
    new JProperty("status", pair.Value.Status.ToString()),
    new JProperty("description", pair.Value.Description),
    new JProperty("Exception", $"{pair.Value.Exception}"),
    new JProperty("data", new JObject(pair.Value.Data.Select(
      p => new JProperty(p.Key, p.Value))))))))));


                    var content = new StringBuilder();
                    content.AppendLine($"{Assembly.GetEntryAssembly().GetName().Name} 监控检测不通过，请相关人员注意。");
                    content.AppendLine("检测结果：");
                    content.AppendLine(json.ToString());

                    var mentionedMobileList = new List<string>() { "@all" };

                    var msg = new
                    {
                        mentioned_mobile_list = mentionedMobileList,
                        msgtype = "markdown",
                        markdown = new
                        {
                            content = content.ToString()
                        }
                    };

                    var stringContent = new StringContent(JsonConvert.SerializeObject(msg), Encoding.UTF8, "application/json");


                    HttpClient httpClient = context.RequestServices.GetService<IHttpClientFactory>()?.CreateClient();
                    httpClient?
                   .PostAsync($"https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={key}", stringContent)
                   .ConfigureAwait(false);
                }

                return context.Response.WriteAsync(
                   "Unhealthy");
            }
        }
}