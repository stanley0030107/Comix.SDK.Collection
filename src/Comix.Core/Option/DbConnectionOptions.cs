using Furion.ConfigurableOptions;
using Microsoft.Extensions.Configuration;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Core.Option;
/// <summary>
/// 数据库配置选项
/// </summary>
public sealed class DbConnectionOptions : IConfigurableOptions<DbConnectionOptions>
{
    /// <summary>
    /// 数据库集合
    /// </summary>
    public List<ConnectionConfig> ConnectionConfigs { get; set; }

    /// <summary>
    /// 是否禁用读写分离
    /// 关闭：默认读从库，可以强制读主库
    /// 开启：默认读主库，可以强制读从库
    /// </summary>
    public bool? IsDisableMasterSlaveSeparation { get; set; }

    public void PostConfigure(DbConnectionOptions options, IConfiguration configuration)
    {
    }
}
