using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Monday.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Monday.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class MondayGraphQlHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="MondayGraphQlHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddMondayGraphQlHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IMondayGraphQlHttpClient, MondayGraphQlHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="MondayGraphQlHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddMondayGraphQlHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IMondayGraphQlHttpClient, MondayGraphQlHttpClient>();

        return services;
    }
}
