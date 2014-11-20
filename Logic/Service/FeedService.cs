using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Data;
using Logic.Entities;
using Logic.Readers;
using Logic.Repositories;
using ComboBox = System.Windows.Controls.ComboBox;
using ListView = System.Windows.Controls.ListView;

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
            repository.FillSomething(feed, path, valjEnstakaNod, nodeToFill);
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
            repository.FillSomething(feed, path, valjEnstakaNod, nodeToFill);
        }

        public string SelectSingleFeed( string chooseFirstDesc ,string selectListItem, string compareWithNode, string selectNode)
        {
            var load = repository.SelectSingleItemInFeed(path, chooseFirstDesc, selectListItem, compareWithNode, selectNode);
            return load;
        }

        //public void TestFeedSelection()
        //{
        //    var load = repository.Load(path);
        //    var list = from lv1 in load
        //        where lv1 == "Title"
        //        select lv1;

        //    StringBuilder sb = new StringBuilder();
        //    foreach (string s in list)
        //    {
        //        sb.Append(s + Environment.NewLine);
        //    }

        //    MessageBox.Show(sb.ToString(), "Found Bird");

        //}
        public void SelectMultipleFeeds(ListView lv, string selectedItem)
        {
            string selectNodes = "ListOfFeeds/FeedList/Feed";
            string singleNodeToCompare = "Namn";
            string singleNode = "Items";
            
            repository.SelectMultipleFeedNames(lv, path, selectNodes, singleNodeToCompare,selectedItem,singleNode);
        }
        public string SortMultiplePlace(string selectedItem)
        {
            string selectNodes = "ListOfFeeds/FeedList/Feed";
            string singleNodeToCompare = "Category";
            

            var load = repository.SelectMultiplePlace(path, selectNodes, singleNodeToCompare, selectedItem);
            return load;
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