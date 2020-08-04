namespace TraceLd.DiscordWebhook.Models
{
    public class WebhookSettings
    {
        public WebhookSettings()
        {
        }

        public WebhookSettings(long id, string token)
        {
            Id = id;
            Token = token;
        }
        
        public long Id { get; set; }
        public string Token { get; set; }
    }
}