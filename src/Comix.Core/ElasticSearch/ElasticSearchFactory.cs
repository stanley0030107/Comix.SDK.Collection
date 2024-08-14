using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace Comix.Core.ElasticSearch;

public class ElasticSearchFactory
{
    private static Dictionary<string, ElasticsearchClient> _clients = new Dictionary<string, ElasticsearchClient>();

    public void AddClient(EsConfig config)
    {
        if (_clients.ContainsKey(config.Name))
        {
            return;
        }
        
        var nodes = config.Uris.Select(u => new Uri(u)).ToArray();
        var pool = new StaticNodePool(nodes);
        var settings = new ElasticsearchClientSettings(pool)
            .DisableAutomaticProxyDetection()
            .DisableDirectStreaming()
            .ServerCertificateValidationCallback((sender, certificate, chain, sslPolicyErrors) => true)
            .Authentication(new BasicAuthentication(config.UserName,config.Password));
        var client = new ElasticsearchClient(settings);

        _clients.Add(config.Name, client);
    }

    public ElasticsearchClient Get(string name)
    {
        var exists = _clients.ContainsKey(name);
        if (!exists)
        {
            return null;
        }

        return _clients[name];
    }

    public bool Exists(string name)
    {
        return _clients.ContainsKey(name);
    }
}