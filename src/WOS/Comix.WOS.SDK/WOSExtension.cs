using Comix.WOS.SDK.Models;
using System;

namespace Comix.WOS.SDK
{
    public static class WOSExtension
    {
        public static void AddService(string url,string credential)
        {
            WOSOptions.Url = url;
            WOSOptions.Credential = credential;
        }
    }
}
