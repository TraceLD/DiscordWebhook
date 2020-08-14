namespace TraceLd.DiscordWebhook.Models
{
    public class EmbedEntity : UrlEntity
    {
        public EmbedEntity()
        {

        }

        public EmbedEntity(string url) : base(url)  
        {
        }

        public EmbedEntity(string url, int width, int height) : base(url)
        {
            Width = width;
            Height = height;
        }

        public int? Width { get; set; }

        public int? Height { get; set; }
    }
}
