using Comix.PMS.SDK;
using Comix.PMS.SDK.Interfaces;
using Comix.PMS.SDK.Services;
using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.PMS.xUnit
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // 注册远程服务 不能删除，删除运行不了
            services.AddRemoteRequest();

            // 注册PMS服务
            var url = App.Configuration["PMS:Url"];
            PMSExtension.AddService(url);
            services.AddScoped<IPMSService, PMSService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
