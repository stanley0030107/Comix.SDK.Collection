using Comix.KuaiDi100.SDK;
using Comix.KuaiDi100.SDK.Interfaces;
using Comix.KuaiDi100.SDK.Models;
using Comix.KuaiDi100.SDK.Services;
using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.KuaiDi100.xUnit
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // 注册远程服务 不能删除，删除运行不了
            services.AddRemoteRequest();

            var config = App.GetConfig<KuaiDi100AddressParseConfig>("KuaiDi100_AddressParse");
            KuaiDi100Extension.AddService(config);
            services.AddScoped<IKuaiDi100Service, KuaiDi100Service>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
