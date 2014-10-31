
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
        private PlayUrl sounds = new PlayUrl();

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
            listEpisode.Items.Clear();
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

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            string flow = listEpisode.SelectedItem.ToString();
                
            XDocument doc = XDocument.Load("Feed.xml");
            var values = doc.Descendants("Feed").Descendants("FeedItem")
                            
                         .Where(i => i.Element("Title").Value == flow)
                         .Select(i => i.Element("Link").Value)
                         .Single();

            Process.Start("wmplayer.exe", values);

        }

        private void cbCategory_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            listFlow.Items.Clear();
            listEpisode.Items.Clear();
            
            string category = cbCategory.SelectedItem.ToString();
            XDocument doc = XDocument.Load("Feed.xml");
            var values = doc.Descendants("FeedList").Descendants("Feed")

                         .Where(i => i.Element("Category").Value == category)
                         .Select(i => i.Element("Namn").Value)
                         .Single();

            listFlow.Items.Add(values);

            
        }


        }
    }

    

