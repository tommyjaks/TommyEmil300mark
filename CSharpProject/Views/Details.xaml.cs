
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Logic.Service;
using WMPLib;
using ComboBox = System.Windows.Controls.ComboBox;
using ListView = System.Windows.Controls.ListView;


namespace CSharpProject.Views
{
   
    public partial class Details : Window
    {

        private CategoryService fillCategories = new CategoryService();
        private FeedService fillFeed = new FeedService();
        

        public Details()
        {
            InitializeComponent();

            ComboBox cbBoxBox = cbCategory;
            fillCategories.GetCategory(cbBoxBox);

            ListView listOfFeed = listFlow;
            fillFeed.GetFeed(listOfFeed);

        }

        private void listFlow_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            listEpisode.UnselectAll();
            listEpisode.Items.Clear();
            if (listFlow.SelectedItem != null)
            {

                string flow = listFlow.SelectedItem.ToString();
                var doc = new XmlDocument();
                doc.Load("Feed.xml");

                XmlNodeList selectedNodes = doc.SelectNodes("ListOfFeeds/FeedList/Feed");

                foreach (XmlNode node in selectedNodes)
                {
                    if (node.SelectSingleNode("Namn").InnerText == flow)
                    {
                        XmlNode feedItem = node.SelectSingleNode("Items");
                        for (int i = 0; i < feedItem.ChildNodes.Count; i++)
                        {
                            listEpisode.Items.Add(feedItem.ChildNodes.Item(i).ChildNodes[1].InnerText);
                        }
                    }
                }
            }
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {          
            string flow = listEpisode.SelectedItem.ToString();
            fillFeed.Play(flow);

            string newNode = "Ja";
            fillFeed.EditPlayedStatus(flow,newNode);
        }

        private void cbCategory_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            listFlow.Items.Clear();
            listEpisode.Items.Clear();
            ListView feed = listFlow;
            string selectListItem = cbCategory.SelectedItem.ToString();            
            string chooseFirstDesc = "Feed";
            string compareWithNode = "Category";
            string selectNode = "Namn";
            
            fillFeed.SelectSingleFeed(feed, chooseFirstDesc,selectListItem,compareWithNode,selectNode);
        }

        private void listEpisode_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(listEpisode.SelectedItem != null){
            listInfo.Items.Clear();
            string selectListItem = listEpisode.SelectedItem.ToString();
            ListView feed = listInfo;

            string chooseFirstDesc = "FeedItem";
            string compareWithNode = "Title";
            string selectNode = "Date";
            fillFeed.SelectSingleFeed(feed, chooseFirstDesc, selectListItem, compareWithNode, selectNode);

            string selectNode2 = "Uppspelad";
            fillFeed.SelectSingleFeed(feed, chooseFirstDesc, selectListItem, compareWithNode, selectNode2);
            }
        }

  



        }
    }

    

