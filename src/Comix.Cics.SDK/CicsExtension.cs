using Comix.Cics.SDK.Model;
using System;

namespace Comix.Cics.SDK
{
    public class CicsExtension
    {
        public static void AddService(string url)
        {
            CicsOptions.Url = url;
        }
    }
}
