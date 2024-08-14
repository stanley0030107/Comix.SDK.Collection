using Comix.Core.Cache;
using Comix.Core.Option;

namespace Comix.Core.Sqlsugar
{
    /// <summary>
    /// Sqlsugar 上下文初始化
    /// </summary>
    /// <param name="services"></param>
    public static class SqlsugarSetup
    {
        public static void AddSqlSugar(this IServiceCollection services)
        {
            var dbOptions = App.GetOptions<DbConnectionOptions>();
            dbOptions.ConnectionConfigs.ForEach(config =>
            {
                SetDbConfig(config);
            });

            SqlSugarScope sqlSugar = new(dbOptions.ConnectionConfigs.Adapt<List<ConnectionConfig>>(), db =>
            {
                dbOptions.ConnectionConfigs.ForEach(config =>
                {
                    config.LanguageType = LanguageType.Chinese;
                    var dbProvider = db.GetConnectionScope(config.ConfigId);
                    SetDbAop(dbProvider);
                });
                //全局禁用读写分离
                if (dbOptions.IsDisableMasterSlaveSeparation.HasValue)
                {
                    db.Ado.IsDisableMasterSlaveSeparation = dbOptions.IsDisableMasterSlaveSeparation.Value;
                }
            });

            services.AddSingleton<ISqlSugarClient>(sqlSugar); // 单例注册
            services.AddScoped(typeof(SqlSugarRepository<>)); // 仓储注册
            services.AddUnitOfWork<SqlSugarUnitOfWork>(); // 事务与工作单元注册
        }

        /// <summary>
        /// 配置连接属性
        /// </summary>
        /// <param name="config"></param>
        public static void SetDbConfig(ConnectionConfig config)
        {
            var configureExternalServices = new ConfigureExternalServices
            {
                DataInfoCacheService = new SqlSugarCache(),
            };
            config.InitKeyType = InitKeyType.Attribute;
            config.IsAutoCloseConnection = true;
            config.MoreSettings = new ConnMoreSettings
            {
                IsAutoRemoveDataCache = true
            };
        }

        /// <summary>
        /// 配置Aop
        /// </summary>
        /// <param name="db"></param>
        public static void SetDbAop(SqlSugarScopeProvider db)
        {
            var config = db.CurrentConnectionConfig;

            // 设置超时时间
            db.Ado.CommandTimeOut = 30;

            // 打印SQL语句
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                if (sql.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                    Console.ForegroundColor = ConsoleColor.Green;
                if (sql.StartsWith("UPDATE", StringComparison.OrdinalIgnoreCase) || sql.StartsWith("INSERT", StringComparison.OrdinalIgnoreCase))
                    Console.ForegroundColor = ConsoleColor.White;
                if (sql.StartsWith("DELETE", StringComparison.OrdinalIgnoreCase))
                    Console.ForegroundColor = ConsoleColor.Blue;
         
                Console.WriteLine($@"
【{DateTime.Now}】——执行SQL
连接字符串：{db.CurrentConnectionConfig.ConnectionString}
{UtilMethods.GetSqlString(config.DbType, sql, pars)}
");
                App.PrintToMiniProfiler("SqlSugar", "Info", sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            };
            db.Aop.OnError = (ex) =>
            {
                if (ex.Parametres == null) return;
                var pars = db.Utilities.SerializeObject(((SugarParameter[])ex.Parametres).ToDictionary(it => it.ParameterName, it => it.Value));
      
                var sql = $@"
【{DateTime.Now}】——执行SQL
连接字符串：{db.CurrentConnectionConfig.ConnectionString}
{UtilMethods.GetSqlString(config.DbType, ex.Sql, (SugarParameter[])ex.Parametres)}
";
                Log.Error($"执行sql异常 {ex.Message} \n {sql}", ex );

                App.PrintToMiniProfiler("SqlSugar", "Error", $"{ex.Message}{Environment.NewLine}{ex.Sql}{pars}{Environment.NewLine}");
            };

            // 数据审计
            db.Aop.DataExecuting = (oldValue, entityInfo) =>
            {
                if (entityInfo.OperationType == DataFilterType.InsertByObject)
                {
                    // 主键(long类型)且没有值的---赋值雪花Id
                    if (entityInfo.EntityColumnInfo.IsPrimarykey && entityInfo.EntityColumnInfo.PropertyInfo.PropertyType == typeof(long))
                    {
                        var id = entityInfo.EntityColumnInfo.PropertyInfo.GetValue(entityInfo.EntityValue);
                        if (id == null || (long)id == 0)
                            entityInfo.SetValue(Yitter.IdGenerator.YitIdHelper.NextId());
                    }
                    if (entityInfo.PropertyName == "CreateTime" && entityInfo is DateTime)
                        entityInfo.SetValue(DateTime.Now);
                }

            };

        }



    }
}
