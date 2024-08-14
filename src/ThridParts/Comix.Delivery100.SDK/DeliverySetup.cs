using Comix.Delivery100.SDK.Interfaces;
using Comix.Delivery100.SDK.Models;
using Comix.Delivery100.SDK.Services;
using Furion;
using Microsoft.Extensions.DependencyInjection;

namespace Comix.Delivery100.SDK
{
    public static class DeliverySetup
    {
        public const string DeliveryHttpClientName = "Delivery";

        /// <summary>
        /// 注入Delivery服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDelivery(this IServiceCollection services)
        {
            services.AddConfigurableOptions<DeliveryOptions>();

            var deliveryOptions = App.GetOptions<DeliveryOptions>();

            services.AddRemoteRequest(options =>
            {
                // 配置 Github 基本信息
                options.AddHttpClient(DeliverySetup.DeliveryHttpClientName, c =>
                {
                    c.BaseAddress = new Uri(deliveryOptions.logistics);
                    c.DefaultRequestHeaders.Add("Accept", "application/json;charset=UTF-8"); 
                });
            });

            services.AddScoped<IDeliveryService, DeliveryService>();

            return services;
        }
    }
}