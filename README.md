[![](https://img.shields.io/nuget/v/soenneker.monday.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.monday.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.monday.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.monday.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.monday.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.monday.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.monday.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.monday.httpclients/actions/workflows/codeql.yml)

# Soenneker.Monday.HttpClients

Provides cached, authenticated `HttpClient` instances for Monday's GraphQL API.

## Install

```bash
dotnet add package Soenneker.Monday.HttpClients
```

## Configuration

```json
{
  "Monday": {
    "ApiKey": "your-api-key"
  }
}
```

`Monday:ClientBaseUrl` can override the default `https://api.monday.com/v2` endpoint. The API key is sent directly in the `Authorization` header, as required by Monday.

## Usage

```csharp
using Soenneker.Monday.HttpClients.Abstract;
using Soenneker.Monday.HttpClients.Registrars;

services.AddMondayGraphQlHttpClientAsSingleton();

IMondayGraphQlHttpClient monday = serviceProvider
    .GetRequiredService<IMondayGraphQlHttpClient>();

HttpClient client = await monday.Get(cancellationToken);
```

Use `Get(apiKey)` for a different token or `Get(apiKey, baseUrl)` for another Monday connection. Calls with the same connection settings reuse the same client within the provider's lifetime.

Do not dispose a returned `HttpClient`; the registered provider owns it and removes it from the cache when disposed.
