namespace Comix.Core.ElasticSearch;

public class EsConfig
{
    public string Name { get; set; }
    public List<string> Uris { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}