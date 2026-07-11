[![](https://img.shields.io/nuget/v/soenneker.monday.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.monday.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.monday.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.monday.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.monday.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.monday.httpclients/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Monday.HttpClients
### A thread-safe singleton HttpClient for Monday's GraphQL integration.

## Installation

```
dotnet add package Soenneker.Monday.HttpClients
```

The parameterless `Get()` uses `Monday:ApiKey` and `Monday:ClientBaseUrl`. Pass connection values explicitly to work with multiple Monday accounts or endpoints:

```csharp
HttpClient tenantClient = await mondayGraphQlHttpClient.Get(tenantApiKey, tenantBaseUrl);
```
