using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comix.RPA.SDK;
using Comix.RPA.SDK.Options;

namespace Comix.PMS.xUnit
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // 注册远程服务 不能删除，删除运行不了
            services.AddRemoteRequest();

            var sapOptions = App.GetOptions<RpaOptions>();

            // 注册RPA服务
            services.AddRpaService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
