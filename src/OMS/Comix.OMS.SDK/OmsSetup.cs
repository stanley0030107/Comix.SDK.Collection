using Comix.OMS.SDK.Interfaces;
using Comix.OMS.SDK.Models;
using Comix.OMS.SDK.RPC;
using Comix.OMS.SDK.Services;
using Furion;
using Furion.DependencyInjection;
using Furion.LinqBuilder;
using Furion.RemoteRequest;
using Microsoft.Extensions.DependencyInjection;

namespace Comix.OMS.SDK
{
    public static class OmsSetup
    {
        public const string OmsHttpClientName = "oms";
        public const string OmsFxHttpClientName = "omsFx";
        public const string DbConfigId = "OMS";
        /// <summary>
        /// 注入Oms服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddOms(this IServiceCollection services)
        {
            services.AddConfigurableOptions<OmsOptions>();
            var omsOptions = App.GetOptions<OmsOptions>();

    
            return services;
        }

        /// <summary>
        /// 注入oms分销rpc服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddOmsDrpRpc(this IServiceCollection services)
        {
            //OMS RPC 配置
            Comix.JsonRpc.NetCoreClient.Utility.GlobalConfiguration.Configuration = Furion.App.Configuration;
            services.AddSingleton<DRPServicesProxy>();

            return services;
        }

        /// <summary>
        /// 注入oms rpc服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddOmsRpc(this IServiceCollection services)
        {
            //OMS RPC 配置
            Comix.JsonRpc.NetCoreClient.Utility.GlobalConfiguration.Configuration = Furion.App.Configuration;
            services.AddSingleton<OMSServicesProxy>();

            return services;
        }
    }
}