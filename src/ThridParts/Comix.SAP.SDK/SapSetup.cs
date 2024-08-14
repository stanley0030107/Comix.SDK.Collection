using Comix.SAP.SDK.Models;
using Furion;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Comix.SAP.SDK
{
    public static class SapSetup
    {
        public const string SapHttpClientName = "sap";

        /// <summary>
        /// 注入Sap服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSap(this IServiceCollection services)
        {
            services.AddConfigurableOptions<SapOptions>();

            var sapOptions = App.GetOptions<SapOptions>();

            services.AddRemoteRequest(options =>
            {
                // 配置 Github 基本信息
                options.AddHttpClient(SapSetup.SapHttpClientName, c =>
                {
                    c.BaseAddress = new Uri(sapOptions.Url);
                    c.DefaultRequestHeaders.Add("Authorization", $"Basic {GetEncodedCredentials(sapOptions.User, sapOptions.Password)}");
                    c.DefaultRequestHeaders.Add("Accept", "application/json;charset=UTF-8");
                });
            });


            return services;
        }

        /// <summary>
        /// 生成 Authorization
        /// </summary>
        /// <returns></returns>
        private static string GetEncodedCredentials(string user, string password)
        {
            string mergedCredentials = string.Format("{0}:{1}", user, password);
            byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
            return Convert.ToBase64String(byteCredentials);
        }
    }
}
