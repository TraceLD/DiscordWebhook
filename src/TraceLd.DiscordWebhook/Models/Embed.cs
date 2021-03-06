﻿using System;
using System.Collections.Generic;

#nullable enable
namespace TraceLd.DiscordWebhook.Models
{
    public class Embed
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public long? Color { get; set; }
        public DateTime? Timestamp { get; set; }
        public Footer? Footer { get; set; }
        public EmbedEntity? Thumbnail { get; set; }
        public EmbedEntity? Image { get; set; }
        public EmbedEntity? Video { get; set; }
        public Author? Author { get; set; }
        public IEnumerable<Field>? Fields { get; set; }
    }
}