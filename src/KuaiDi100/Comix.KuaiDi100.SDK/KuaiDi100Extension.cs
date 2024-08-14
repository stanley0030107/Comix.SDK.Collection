using Comix.KuaiDi100.SDK.Models;
using System;

namespace Comix.KuaiDi100.SDK
{
    public static class KuaiDi100Extension
    {
        public static KuaiDi100AddressParseConfig kuaiDi100Config { get; set; }
        public static void AddService(KuaiDi100AddressParseConfig config)
        {
            kuaiDi100Config = config;
        }
    }
}
