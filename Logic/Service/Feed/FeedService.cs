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
        

        public void getRssItems(string url)
        {
            string path = "Feed.xml";
            List<FeedItem> feedData = feedReader.Read(url);
            repository.Save(feedData, path);
        }

    }
}