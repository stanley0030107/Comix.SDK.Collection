using Comix.COM.SDK.Models;
using System;

namespace Comix.COM.SDK
{
    public static class COMExtension
    {
        public static void AddService(string url)
        {
            COMOptions.Url = url;
        }
    }
}
