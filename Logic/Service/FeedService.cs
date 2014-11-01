using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Data;
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
        string path = "Feed.xml";
        
      
        

        public void getRssItems(string url, string name, string category)
        {
            string path = "Feed.xml";

            createFeeds = repository.Load(path);
            repository.Save(createFeeds, path);
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
            string chooseNode = "ListOfFeeds/FeedList/Feed";
            string chooseSingleNode = "Category";
            string elementToCreate = "Category";

           
            repository.Update(xmlFile, chooseNode, chooseSingleNode, selectedCategory, elementToCreate, newNode);
        }
        public void SetFeed(ComboBox feed)
        {
            string path = "Feed.xml";

            string valjEnstakaNod = "ListOfFeeds/FeedList/Feed";
            string nodeToFill = "Namn";
            repository.fillComboBox(feed, path, valjEnstakaNod, nodeToFill);
        }

        public void getFeedUpdateInfo(string selectedFeed, string newName, string newUrl, string newCategory)
        {
            

            repository.UpdateFeed(path, selectedFeed, newName, newUrl, newCategory);
        }

        public void GetFeedToRemove(string selectedFeed)
        {
            string selectedNodeToRemove = "Feed";
            string selectedElement = "Namn";

            repository.RemoveData(selectedFeed, path, selectedNodeToRemove, selectedElement);  
        }


        public void GetFeed(ListView feed)
        {
          

            string valjEnstakaNod = "ListOfFeeds/FeedList/Feed";
            string nodeToFill = "Namn";
            repository.FillListView(feed, path, valjEnstakaNod, nodeToFill);
        }

        public void SelectSingleFeed()
        {
            
        }

    }
}