# DiscordWebhook

[![Actions Status](https://github.com/TraceLD/DiscordWebhook/workflows/build/badge.svg)](https://github.com/TraceLD/DiscordWebhook/actions)
[![nuget](https://img.shields.io/nuget/v/TraceLd.DiscordWebhook)](https://www.nuget.org/packages/TraceLd.DiscordWebhook/)

Extremely simple and lightweight library for hooking up a Discord webhook meant to be used with ASP.NET Core or the Generic Host.

Built-in support for `Microsoft.Extensions.Logging`'s `ILogger<T>` (does not work without it, injected via DI) and embeds via `TraceLd.DiscordWebhook.Models.Embed`.

## Usage example

The following example will use ASP.NET Core but the setup is almost identical with the Generic Host.

1. Add `WebhookSettings` as a singleton. Where it comes from is up to you - it can be config files, environment variables etc. In this simple example we will use `appsettings.json`. (It is not the most secure option as the credentials are stored in plaintext, but it's very simple).

- Add the following section to `appsettings.json` and fill it in with your credentials:

```json
"WebhookSettings": {
    "Id": 0000000,
    "Token": "token"
}
```

- Add the following code to the `ConfigureServices` method in `Startup.cs`:

```cs
services.Configure<WebhookSettings>(Configuration.GetSection(nameof(WebhookSettings)));
services.AddSingleton(provider => provider.GetRequiredService<IOptions<WebhookSettings>>().Value);
```

2. Add `IWebhookService`:

- Add the following code to `Startup.cs` *below* the previously added code:

```cs
services.AddHttpClient<IWebhookService, WebhookService>();
```

3. Now you can use the webhook service in your own services, for example:

- Create the service:

```cs
public interface IHelloService
{
    Task SendHelloAsync();
}

public class HelloService : IHelloService
{
    private readonly ILogger<HelloService> _logger;
    private readonly IWebhookService _webhookService;

    public HelloService(ILogger<HelloService> logger, IWebhookService webhookService)
    {
        _logger = logger;
        _webhookService = webhookService;
    }

    public async Task SendHelloAsync()
    {
        await _webhookService.ExecuteWebhookAsync("Hello from C#");
    }
}
```

- Add the service in `Startup.cs` (*below* the previous code):

```cs
services.AddScoped<IHelloService, HelloService>();
```
