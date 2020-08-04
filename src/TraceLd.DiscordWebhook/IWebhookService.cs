using System.Collections.Generic;
using System.Threading.Tasks;
using TraceLd.DiscordWebhook.Models;

namespace TraceLd.DiscordWebhook
{
    public interface IWebhookService
    {
        Task ExecuteWebhookAsync(WebhookMessage webhookMessage);
        Task ExecuteWebhookAsync(string messageContent, IEnumerable<Embed> embeds);
        Task ExecuteWebhookAsync(string messageContent, Embed embed);
        Task ExecuteWebhookAsync(string messageContent);
        Task ExecuteWebhookAsync(IEnumerable<Embed> embeds);
        Task ExecuteWebhookAsync(Embed embed);
    }
}