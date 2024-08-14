namespace Comix.Core.ElasticSearch.Util;

public enum EsQueryType
{
    /// <summary>
    /// 大于
    /// </summary>
    [Description("大于")] Gt = 1,

    /// <summary>
    /// 大于等于
    /// </summary>
    [Description("大于等于")] Gte = 2,

    /// <summary>
    /// 小于
    /// </summary>
    [Description("小于")] Lt = 3,

    /// <summary>
    /// 小于等于
    /// </summary>
    [Description("小于等于")] Lte = 4,

    /// <summary>
    /// 包含
    /// </summary>
    [Description("包含")] Like = 5,

    /// <summary>
    /// 不包含
    /// </summary>
    [Description("不包含")] NotLike = 6,

    /// <summary>
    /// 在。。。中
    /// </summary>
    [Description("在。。。中")] In = 7,

    /// <summary>
    /// 不在。。。中
    /// </summary>
    [Description("不在。。。中")] NotIn = 8,

    /// <summary>
    /// 等于
    /// </summary>
    [Description("等于")] Equals = 9,

    /// <summary>
    /// 不等于
    /// </summary>
    [Description("不等于")] NotEquals = 10
}

public class EsQueryTypeEx
{
    public static EsQueryType[] RangeQueryType => new[]
    {
        EsQueryType.Gt,
        EsQueryType.Gte,
        EsQueryType.Lt,
        EsQueryType.Lte
    };
}