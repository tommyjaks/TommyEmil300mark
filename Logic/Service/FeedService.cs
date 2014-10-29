using System;
using System.Collections.Generic;
using Logic.Entities;
using Logic.Readers;
using Logic.Repositories;

namespace Logic.Service
{
    public class FeedService
    {
        private Repository<ListOfFeeds> repository = new Repository<ListOfFeeds>();
        private ListOfFeeds skapaFeeds = new ListOfFeeds();
        private RssReader feedReader = new RssReader();
        
      
        

        public void getRssItems(string url, string name, string category)
        {
            string path = "Feed.xml";
           
            skapaFeeds = repository.Load(path);
            repository.Save(skapaFeeds, path);
            
         

            var feed = new Feed()
            {
                Url = url,
                Id = Guid.NewGuid(),
                Namn = name,
                Category = category,
                
                Items = feedReader.Read(url)
               


            };
          skapaFeeds.AddFeedToList(feed);
           
        

        
           

            repository.Save(skapaFeeds, path);
        }
        public void EditCategoryInFeedXmlFile(string selectedCategory, string newNode)
        {
            string xmlFile = "Feed.xml";
            string chooseNode = "ArrayOfFeedItem/FeedItem";
            string chooseSingleNode = "Category";
            string elementToCreate = "Category";

           
            repository.Update(xmlFile, chooseNode, chooseSingleNode, selectedCategory, elementToCreate, newNode);
        }

    }
}