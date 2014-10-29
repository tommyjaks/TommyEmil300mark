using System;

namespace Logic.Entities
{
    public class FeedItem : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get ; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
    }
    
}