using Comix.AiService.Options;
using Furion;
using Furion.FriendlyException;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.AiService
{
    public static class AiServiceSetup
    {
        public const string RpaHttpClientName = "AiService";

        /// <summary>
        /// 注入Rpa服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAiService(this IServiceCollection services)
        {
            //获取配置
            services.AddConfigurableOptions<AiServiceOptions>();
            var config = App.GetOptions<AiServiceOptions>();

            if (config == null || string.IsNullOrEmpty(config.Url))
                throw Oops.Bah("缺少AiService节点的配置");

            services.AddRemoteRequest(options =>
            {
                // 配置特定客户端
                options.AddHttpClient(AiServiceSetup.RpaHttpClientName, c =>
                {
                    c.BaseAddress = new Uri(config.Url);
                });
            });

            return services;
        }
    }
}
