using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Monday.HttpClients.Abstract;

/// <summary>
/// A .NET thread-safe singleton HttpClient for 
/// </summary>
public interface IMondayGraphQlHttpClient: IDisposable, IAsyncDisposable
{
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);

    /// <summary>Gets a client for a specific API key using the configured base URL.</summary>
    ValueTask<HttpClient> Get(string apiKey, CancellationToken cancellationToken = default);

    /// <summary>Gets a client for a specific Monday connection.</summary>
    ValueTask<HttpClient> Get(string apiKey, string baseUrl, CancellationToken cancellationToken = default);
}
