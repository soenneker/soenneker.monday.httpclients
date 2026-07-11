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
}
