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
            
            string chooseNode = "ListOfFeeds/FeedList/Feed";
            string chooseSingleNode = "Category";
            string elementToCreate = "Category";

           
            repository.Update(path, chooseNode, chooseSingleNode, selectedCategory, elementToCreate, newNode);
        }
        public void SetFeed(ComboBox feed)
        {
           

            string valjEnstakaNod = "ListOfFeeds/FeedList/Feed";
            string nodeToFill = "Namn";
            repository.FillComboBox(feed, path, valjEnstakaNod, nodeToFill);
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

        public void SelectSingleFeed(ListView feed,string chooseFirstDesc ,string selectListItem, string compareWithNode, string selectNode)
        {
            repository.SelectSingleItemInFeed(feed, path, chooseFirstDesc, selectListItem, compareWithNode, selectNode);
        }

        public void Play(string selectedListItem)
        {
            string chooseFirstDesc = "FeedItem";
            string compareWithNode = "Title";
            string selectNode = "Link";

            repository.Play(path,chooseFirstDesc,selectedListItem,compareWithNode,selectNode);
        }
        public void EditPlayedStatus(string selectedCategory, string newNode)
        {

            string chooseNode = "ListOfFeeds/FeedList/Feed/FeedItem";
            string chooseSingleNode = "Title";
            string elementToCreate = "Uppspelad";


            repository.Update(path, chooseNode, chooseSingleNode, selectedCategory, elementToCreate, newNode);
        }

    }
}