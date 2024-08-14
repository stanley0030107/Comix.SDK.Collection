
using Comix.COS.SDK.Interfaces;
using Comix.COS.SDK.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Comix.COS.SDK
{
  public static class COSExtension
    {
        public static void AddCosService(string url)
        {
            COSOptions.Url = url;
        }

        public static IServiceCollection AddCosService(this IServiceCollection service, string url)
        {
            COSOptions.Url = url;

            service.AddScoped<ICOSBranchService, COSBranchService>();
            service.AddScoped<ICOSCategoryService, COSCategoryService>();
            service.AddScoped<ICOSImageSearchService, COSImageSearchService>();
            service.AddScoped<ICOSProductService, COSProductService>();
            service.AddScoped<ICOSMdnService, COSMdnService>();
            service.AddScoped<ICosMessageListService, CosMessageListService>();

            return service;
        }
    }
}
