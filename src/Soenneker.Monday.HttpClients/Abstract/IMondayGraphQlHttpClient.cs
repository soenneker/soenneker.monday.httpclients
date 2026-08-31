using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Monday.HttpClients.Abstract;

/// <summary>
/// Provides cached, authenticated HTTP clients for Monday's GraphQL API.
/// </summary>
public interface IMondayGraphQlHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets a client using the configured API key and base URL.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a client for a specific API key using the configured base URL.
    /// </summary>
    /// <param name="apiKey">API key used to authenticate the request.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested HTTP client.</returns>
    ValueTask<HttpClient> Get(string apiKey, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a client for a specific Monday connection.
    /// </summary>
    /// <param name="apiKey">API key used to authenticate the request.</param>
    /// <param name="baseUrl">Absolute Monday GraphQL endpoint to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested HTTP client.</returns>
    ValueTask<HttpClient> Get(string apiKey, string baseUrl, CancellationToken cancellationToken = default);
}
