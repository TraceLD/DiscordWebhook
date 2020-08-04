using System.Collections.Generic;

namespace TraceLd.DiscordWebhook.Models
{
    public class WebhookMessage
    {
        public WebhookMessage()
        {
        }

        public WebhookMessage(string content, IEnumerable<Embed> embeds)
        {
            Content = content;
            Embeds = embeds;
        }
        
        public string Content { get; set; }
        public IEnumerable<Embed> Embeds { get; set; }
    }
}