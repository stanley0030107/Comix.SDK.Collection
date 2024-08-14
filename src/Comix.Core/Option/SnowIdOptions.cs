using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Core.Option;
/// <summary>
/// 雪花Id配置选项
/// </summary>
public sealed class SnowIdOptions : IConfigurableOptions
{
    /// <summary>
    /// 机器码
    /// </summary>
    public ushort WorkerId { get; set; }
}
