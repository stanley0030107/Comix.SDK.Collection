using Comix.OpenAi.SDK.Common;
using Comix.OpenAi.SDK.Interfaces;
using Comix.OpenAi.SDK.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.OpenAi.SDK
{
    public static class OpenAiExtension
    {
        public static OpenAiOptions openAiOptions;

        public static IServiceCollection AddOpenAiService(this IServiceCollection service, OpenAiOptions options)
        {
            openAiOptions = options;

            service.AddScoped<IOpenAiService, OpenAiService>();
            return service;
        }
    }
}
