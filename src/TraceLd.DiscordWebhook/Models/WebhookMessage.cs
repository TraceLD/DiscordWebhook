using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        public string Username { get; set; } = null;

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; } = null;

        [JsonPropertyName("tts")]
        public bool TTS { get; set; } = false;

        public string Content { get; set; }

        public IEnumerable<Embed> Embeds { get; set; }
    }
}