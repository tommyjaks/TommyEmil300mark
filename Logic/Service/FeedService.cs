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
        private ListOfFeeds createFeeds = new ListOfFeeds();
        private RssReader feedReader = new RssReader();
        
      
        

        public void getRssItems(string url, string name, string category)
        {
            string path = "Feed.xml";


            repository.Save(createFeeds, path);
                createFeeds = repository.Load(path);
            
         

            var feed = new Feed()
            {
                Url = url,
                Id = Guid.NewGuid(),
                Namn = name,
                Category = category,
                
                Items = feedReader.Read(url)
               


            };
        createFeeds.AddFeedToList(feed);
           
        

        
           

            repository.Save(createFeeds, path);
        }
        public void EditCategoryInFeedXmlFile(string selectedCategory, string newNode)
        {
            string xmlFile = "Feed.xml";
            string chooseNode = "ArrayOfFeedItem/FeedItem";
            string chooseSingleNode = "CategoryName";
            string elementToCreate = "CategoryName";

           
            repository.Update(xmlFile, chooseNode, chooseSingleNode, selectedCategory, elementToCreate, newNode);
        }

    }
}