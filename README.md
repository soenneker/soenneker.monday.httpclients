[![](https://img.shields.io/nuget/v/soenneker.monday.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.monday.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.monday.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.monday.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.monday.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.monday.httpclients/)

# Soenneker.Monday.HttpClients

A .NET thread-safe singleton HttpClient for.

## Install

```bash
dotnet add package Soenneker.Monday.HttpClients
```

## Quick start

```csharp
using Soenneker.Monday.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddMondayGraphQlHttpClientAsSingleton();
```

Adds `MondayGraphQlHttpClient` as a singleton service.

## What you get

- `IMondayGraphQlHttpClient` — A .NET thread-safe singleton HttpClient for.
- `MondayGraphQlHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IMondayGraphQlHttpClient.Get(apiKey, cancellationToken)` | Gets a client for a specific API key using the configured base URL. | A task whose result is the requested HTTP client. |
| `IMondayGraphQlHttpClient.Get(apiKey, baseUrl, cancellationToken)` | Gets a client for a specific Monday connection. | A task whose result is the requested HTTP client. |
| `MondayGraphQlHttpClientRegistrar.AddMondayGraphQlHttpClientAsSingleton(services)` | Adds `MondayGraphQlHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `MondayGraphQlHttpClientRegistrar.AddMondayGraphQlHttpClientAsScoped(services)` | Adds `MondayGraphQlHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
