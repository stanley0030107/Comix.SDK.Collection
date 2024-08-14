namespace Comix.Core.DbMonitor;

/// <summary>
/// es索引特性
/// </summary>
public class EsIndexAttribute : Attribute
{
    public EsIndexAttribute(string indexName)
    {
        IndexName = indexName;
    }

    public string IndexName { get; set; }
}