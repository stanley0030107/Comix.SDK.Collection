namespace Comix.Core.ElasticSearch.Util;

public enum EsAndOr
{
    /// <summary>
    /// 逻辑和
    /// </summary>
    [Description("和")] 
    And = 1,

    /// <summary>
    /// 逻辑或
    /// </summary>
    [Description("或")] 
    Or = 2,
}