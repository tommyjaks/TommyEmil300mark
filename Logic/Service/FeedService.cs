﻿using System;
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
        private Repository<ListOfFeeds> repository = new Repository<ListOfFeeds>();
        private ListOfFeeds createFeeds = new ListOfFeeds();
        private RssReader feedReader = new RssReader();
        string path = "Feed.xml";
        
      
        

        public void getRssItems(string url, string name, string category, string selectedUpdateInterval)
        {
            repository.Save(createFeeds, path);
            createFeeds = repository.Load(path);
            
            var feed = new Feed()
            {
                Url = url,
                Id = Guid.NewGuid(),
                Namn = name,
                Category = category,
                UppdateInterval = selectedUpdateInterval,
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

        public void getFeedUpdateInfo(string selectedFeed, string newName, string newUrl,string interval, string newCategory)
        {
            

            repository.UpdateFeed(path, selectedFeed, newName, newUrl, interval, newCategory);
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

        public void SelectSingleFeed(ListView feed, string chooseFirstDesc ,string selectListItem, string compareWithNode, string selectNode)
        {
            repository.SelectSingleItemInFeed(feed, path, chooseFirstDesc, selectListItem, compareWithNode, selectNode);
        }

        public void SelectMultipleFeeds(ListView lv, string selectedItem)
        {
            string selectNodes = "ListOfFeeds/FeedList/Feed";
            string singleNodeToCompare = "Namn";
            string singleNode = "Items";
            
            repository.SelectMultipleFeedNames(lv, path, selectNodes, singleNodeToCompare,selectedItem,singleNode);
        }
        public void SortMultiplePlace(ListView lv, string selectedItem)
        {
            string selectNodes = "ListOfFeeds/FeedList/Feed";
            string singleNodeToCompare = "Category";
            

            repository.SelectMultiplePlace(lv, path, selectNodes, singleNodeToCompare, selectedItem);
        }

        public void Play(string selectedListItem)
        {
            string chooseFirstDesc = "FeedItem";
            string compareWithNode = "Title";
            string selectNode = "Link";

            repository.Play(path,chooseFirstDesc,selectedListItem,compareWithNode,selectNode);
        }
        public void EditPlayedStatus(string selectedItem)
        {

            string chooseNode = "FeedItem";
            string chooseSingleNode = "Title";
            string elementToCreate = "Uppspelad";
            string status = "Ja";

            repository.EditSingleNode(path,chooseNode,chooseSingleNode,selectedItem,elementToCreate,status);
        }

        


    }
}