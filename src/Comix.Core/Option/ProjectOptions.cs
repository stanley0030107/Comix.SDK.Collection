using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Core.Option
{
    public static class ProjectOptions
    {
        /// <summary>
        /// 注册项目配置选项
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddProjectOptions(this IServiceCollection services)
        {
            services.AddConfigurableOptions<DbConnectionOptions>();
            services.AddConfigurableOptions<SnowIdOptions>();
            services.AddConfigurableOptions<CacheOptions>();
            services.AddConfigurableOptions<NacosConfigOptions>();
            services.AddConfigurableOptions<OSSProviderOptions>();
            services.AddConfigurableOptions<EmailOptions>();

            return services;
        }
    }
}
