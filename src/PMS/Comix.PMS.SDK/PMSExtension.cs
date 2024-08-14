using Comix.PMS.SDK.Models;
using System;

namespace Comix.PMS.SDK
{
    public static class PMSExtension
    {
        public static void AddService(string url)
        {
            PMSOptions.Url = url;
        }
    }
}
