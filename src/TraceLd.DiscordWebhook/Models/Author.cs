using System.Text.Json.Serialization;

namespace TraceLd.DiscordWebhook.Models
{
    public class Author
    {
        public string Name { get; set; }
        
        public string Url { get; set; }
        
        [JsonPropertyName("icon_url")]
        public string IconUrl { get; set; }
    }
}