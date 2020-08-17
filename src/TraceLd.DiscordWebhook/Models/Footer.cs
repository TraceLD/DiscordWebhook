using System.Text.Json.Serialization;

namespace TraceLd.DiscordWebhook.Models
{
    public class Footer
    {
        public Footer()
        {

        }

        public Footer(string text)
        {
            Text = text;
        }
             
        public Footer(string iconUrl, string text)
        {
            IconUrl = iconUrl;
            Text = text;
        }

        [JsonPropertyName("icon_url")]
        public string IconUrl { get; set; } = null;

        public string Text { get; set; }
    }
}