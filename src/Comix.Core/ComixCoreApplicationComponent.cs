using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Comix.Core
{
    public class ComixCoreApplicationComponent : IApplicationComponent
    {
        public void Load(IApplicationBuilder app, IWebHostEnvironment env, ComponentContext componentContext)
        {
            var logger = App.GetService<ILogger<ComixCoreApplicationComponent>>();
            logger.LogError($"应用启动");
        }
    }
}
