using System;
using DotNetCore.CAP.Internal;
using DotNetCore.CAP.Processor;
using DotNetCore.CAP.Transport;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DotNetCore.CAP.RocketMQ4
{
    internal sealed class RabbitMQCapOptionsExtension : ICapOptionsExtension
    {
        private readonly Action<RocketMQOptions> _configure;

        public RabbitMQCapOptionsExtension(Action<RocketMQOptions> configure)
        {
            _configure = configure;
        }

        public void AddServices(IServiceCollection services)
        {
            services.AddSingleton(new CapMessageQueueMakerService("RabbitMQ"));

            services.Configure(_configure);
            services.AddSingleton<ITransport, RocketMQTransport>();
            services.AddSingleton<IConsumerClientFactory, RocketMQConsumerClientFactory>();

            services.RemoveAll<IConsumerRegister>();
            services.RemoveAll<IProcessingServer>();

            services.TryAddEnumerable(
                ServiceDescriptor.Singleton<IProcessingServer, IDispatcher>(sp =>
                    sp.GetRequiredService<IDispatcher>()));
            
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IProcessingServer, IConsumerRegister>(sp =>
                    sp.GetRequiredService<IConsumerRegister>()));
            
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IProcessingServer, CapProcessingServer>());
            
            services.AddSingleton<IConsumerRegister, RocketConsumerRegister>();
            // services.TryAddEnumerable(ServiceDescriptor.Singleton<IProcessingServer, RocketConsumerRegister>());

            
            services.RemoveAll<ISubscribeExecutor>();
            services.AddSingleton<ISubscribeExecutor, RocketSubscribeExecutor>();
        }
    }
}