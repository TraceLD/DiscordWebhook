namespace TraceLd.DiscordWebhook.Models
{
    public class Field
    {
        public Field()
        {
        }

        public Field(string name, string value, bool inline = false)
        {
            Name = name;
            Value = value;
            Inline = inline;
        }
        
        public string Name { get; set; }

        public string Value { get; set; }

        public bool? Inline { get; set; }
    }
}