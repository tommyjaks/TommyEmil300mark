using System;
using System.Collections.Generic;
using Data;
using Logic.Entities;
using Logic.Readers;
using Logic.Repositories;

namespace Logic.Service.Feed
{
    public class FeedService
    {
        private RssReader feedReader = new RssReader();
        private Repository<FeedItem> repository = new Repository<FeedItem>();
        

        public void getRssItems(string url, string name, string category)
        {
            string path = "Feed.xml";
            List<FeedItem> feedData = new List<FeedItem>();
            
            if (feedReader != null) feedData = feedReader.Read(url, name, category);


            repository.Save(feedData, path);
        }

    }
}