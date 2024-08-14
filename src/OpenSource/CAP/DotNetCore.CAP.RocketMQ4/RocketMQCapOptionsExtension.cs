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
            services.AddSingleton<CapMessageQueueMakerService>();

            services.Configure(_configure);
            services.AddSingleton<ITransport, RocketMQTransport>();
            services.AddSingleton<IConsumerClientFactory, RocketMQConsumerClientFactory>();

            services.RemoveAll<IConsumerRegister>();
            services.RemoveAll<IProcessingServer>();
            services.AddSingleton<IProcessingServer, RocketConsumerRegister>();
            services.AddSingleton<IConsumerRegister, RocketConsumerRegister>();
            // services.TryAddEnumerable(ServiceDescriptor.Singleton<IProcessingServer, RocketConsumerRegister>());

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IProcessingServer, CapProcessingServer>());
            
            services.RemoveAll<ISubscribeDispatcher>();
            services.AddSingleton<ISubscribeDispatcher, RocketSubscribeDispatcher>();
        }
    }
}