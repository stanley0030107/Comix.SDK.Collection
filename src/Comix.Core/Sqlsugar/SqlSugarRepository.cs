namespace Comix.Core.Sqlsugar;
/// <summary>
/// SqlSugar仓储类
/// </summary>
/// <typeparam name="T"></typeparam>
public class SqlSugarRepository<T> : SimpleClient<T> where T : class, new()
{
    protected ITenant iTenant = null; // 多租户事务

    public SqlSugarRepository()
    {
    }

    public SqlSugarRepository(ISqlSugarClient context = null) : base(context)
    {
        // 若实体贴有多库特性，则返回指定的连接
        if (typeof(T).IsDefined(typeof(TenantAttribute), false))
        {
            iTenant = App.GetRequiredService<ISqlSugarClient>().AsTenant();
            Context = iTenant.GetConnectionScopeWithAttr<T>();
            return;
        }

        Context = App.GetService<ISqlSugarClient>();//用手动获取方式支持切换仓储
    }
}
