using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Core.Option
{
    public sealed class NacosConfigOptions : IConfigurableOptions
    {
        public string customerCode { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
    }
}
