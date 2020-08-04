namespace TraceLd.DiscordWebhook.Models
{
    public class UrlEntity
    {
        public UrlEntity()
        {
        }

        public UrlEntity(string url)
        {
            Url = url;
        }
        
        public string Url { get; set; }
    }
}