using Comix.B2B.SDK.DBService;
using Comix.B2B.SDK.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.B2B.SDK
{
    public static class B2bSetup
    {
        public const string ConfigId = "B2B";

        /// <summary>
        /// 注入B2B服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddB2B(this IServiceCollection services)
        {
            services.AddScoped<IB2bService, DbB2bService>();
            return services;
        }
    }
}
