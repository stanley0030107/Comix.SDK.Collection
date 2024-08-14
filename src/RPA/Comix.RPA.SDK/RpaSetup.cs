using Comix.RPA.SDK.Options;
using Furion;
using Furion.FriendlyException;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.RPA.SDK
{
    public static class RpaSetup
    {
        public const string RpaHttpClientName = "rpa";

        /// <summary>
        /// 注入Rpa服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRpaService(this IServiceCollection services)
        {
            //获取配置
            services.AddConfigurableOptions<RpaOptions>();
            var sapOptions = App.GetOptions<RpaOptions>();

            if (sapOptions == null || string.IsNullOrEmpty(sapOptions.Url))
                throw Oops.Bah("缺少Rpa节点的配置");

            services.AddRemoteRequest(options =>
            {
                // 配置特定客户端
                options.AddHttpClient(RpaSetup.RpaHttpClientName, c =>
                {
                    c.BaseAddress = new Uri(sapOptions.Url);
                    //c.DefaultRequestHeaders.Add("Authorization", $"Basic {GetEncodedCredentials(sapOptions.User, sapOptions.Password)}");
                    //c.DefaultRequestHeaders.Add("Accept", "application/json;charset=UTF-8");
                });
            });

            return services;
        }
    }
}
