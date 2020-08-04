using System.Text.Json.Serialization;

namespace TraceLd.DiscordWebhook.Models
{
    public class Footer
    {
        [JsonPropertyName("icon_url")]
        public string IconUrl { get; set; }
        
        public string Text { get; set; }
    }
}