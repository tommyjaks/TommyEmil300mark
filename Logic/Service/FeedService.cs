using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;
using Data;
using Logic.Entities;
using Logic.Readers;
using Logic.Repositories;

namespace Logic.Service
{
    public class FeedService
    {
       public Repository<Feed> repository = new Repository<Feed>();
        public List<Feed> createFeeds = new List<Feed>();

       public RssReader feedReader = new RssReader();
        string path = "Feed.xml";
        
      
        

        public void GetRssItems(string url, string name,string category, string selectedUpdateInterval)
        {
            createFeeds = repository.Load(path);
            repository.Save(createFeeds, path);
           
            var feed = new Feed()
            {
                Url = url,
                Id = Guid.NewGuid(),
                Namn = name,
                Category = category,
                UppdateInterval = selectedUpdateInterval,
                Items = feedReader.Read(url)      
            };
            createFeeds.Add(feed);
           repository.Save(createFeeds, path);
        }
  
        public List<Feed> GetAllFeeds()
        {
            return repository.Load(path);
        }


    }
}