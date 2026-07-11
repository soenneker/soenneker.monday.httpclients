using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Extensions.Configuration;
using Soenneker.Monday.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Monday.HttpClients;

///<inheritdoc cref="IMondayGraphQlHttpClient"/>
public sealed class MondayGraphQlHttpClient : IMondayGraphQlHttpClient
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly IConfiguration _config;

    private const string _prodBaseUrl = "https://api.monday.com/v2";

    public MondayGraphQlHttpClient(IHttpClientCache httpClientCache, IConfiguration config)
    {
        _httpClientCache = httpClientCache;
        _config = config;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(MondayGraphQlHttpClient), (config: _config, baseUrl: _config["Monday:ClientBaseUrl"] ?? _prodBaseUrl), static state =>
        {
            var apiKey = state.config.GetValueStrict<string>("Monday:ApiKey");
            string authHeaderName = state.config["Monday:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = state.config["Monday:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            return new HttpClientOptions
            {
                BaseAddress = new Uri(state.baseUrl),
                DefaultRequestHeaders = new Dictionary<string, string>
                {
                    {authHeaderName, authHeaderValue},
                }
            };
        }, cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(MondayGraphQlHttpClient));
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(nameof(MondayGraphQlHttpClient));
    }
}
