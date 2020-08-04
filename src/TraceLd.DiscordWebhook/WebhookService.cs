using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TraceLd.DiscordWebhook.Models;

namespace TraceLd.DiscordWebhook
{
    public class WebhookService : IWebhookService
    {
        private readonly ILogger<WebhookService> _logger;
        private readonly WebhookSettings _settings;
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };
        
        public WebhookService(HttpClient client, WebhookSettings settings)
        {
            _settings = settings;
            
            client.BaseAddress = new Uri("https://discord.com/api/");
            _client = client;
        }

        public WebhookService(ILogger<WebhookService> logger, HttpClient client, WebhookSettings settings)
        {
            _logger = logger;
            _settings = settings;
            
            client.BaseAddress = new Uri("https://discord.com/api/");
            _client = client;
        }
        
        public async Task ExecuteWebhookAsync(WebhookMessage webhookMessage)
        {
            var json = JsonSerializer.Serialize(webhookMessage, _jsonSerializerOptions);
            var post = await _client
                .PostAsync($"webhooks/{_settings.Id}/{_settings.Token}", new StringContent(json, Encoding.UTF8, "application/json"))
                .ConfigureAwait(false);
            post.EnsureSuccessStatusCode();
        }

        public async Task ExecuteWebhookAsync(string messageContent, IEnumerable<Embed> embeds)
        {
            var webhookMessage = new WebhookMessage(messageContent, embeds);
            await ExecuteWebhookAsync(webhookMessage).ConfigureAwait(false);
        }

        public async Task ExecuteWebhookAsync(string messageContent, Embed embed)
        {
            var webhookMessage = new WebhookMessage(messageContent, new List<Embed>{embed});
            await ExecuteWebhookAsync(webhookMessage).ConfigureAwait(false);
        }

        public async Task ExecuteWebhookAsync(string messageContent)
        {
            var webhookMessage = new WebhookMessage(messageContent, new Embed[0]);
            await ExecuteWebhookAsync(webhookMessage).ConfigureAwait(false);
        }

        public async Task ExecuteWebhookAsync(IEnumerable<Embed> embeds)
        {
            var webhookMessage = new WebhookMessage("", embeds);
            await ExecuteWebhookAsync(webhookMessage).ConfigureAwait(false);
        }

        public async Task ExecuteWebhookAsync(Embed embed)
        {
            var webhookMessage = new WebhookMessage("", new List<Embed>{embed});
            await ExecuteWebhookAsync(webhookMessage).ConfigureAwait(false);
        }
    }
}