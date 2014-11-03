using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace Logic.Entities
{
    public class Feed : IEntity
    {
        public string Url { get; set; }
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Namn { get; set; }
        public string UppdateInterval { get; set; }
        
        
        public List<FeedItem> Items { get; set; }

        public Feed()
        {
            Items = new List<FeedItem>();
        }

        public void AddFeedItem(FeedItem feeditem)
        {
            Items.Add(feeditem);
        }

        public void SetIT(Guid id)
        {
            id = Id;
        }
    }

}
