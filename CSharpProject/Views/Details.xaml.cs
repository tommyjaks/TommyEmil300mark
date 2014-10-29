
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Xml;
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
            string path = "http://traffic.libsyn.com/sweclockers/sweclockers_podcast_20140418.mp3";
            Process.Start("wmplayer.exe", path );



            //  string flow = listEpisode.SelectedItem.ToString();
            //  var doc = new XmlDocument();
            //  doc.Load("Feed.xml");
            //  XmlNodeList selectedNodes = doc.SelectNodes("ListOfFeeds/FeedList/Feed");
            //  WMPLib.WindowsMediaPlayer axMusicPlayer = new WMPLib.WindowsMediaPlayer();


            //  foreach (XmlNode node in selectedNodes)
            //{
            //    if (node.SelectSingleNode("Title").InnerText == flow)
            //    {
            //        XmlNode feedItem = node.SelectSingleNode("Items");


            //        for (int i = 0; i < feedItem.ChildNodes.Count; i++)
            //        {
            //           var sound = feedItem.ChildNodes.Item(i).LastChild.InnerText;

            //        }
            //    }
            //}
        }

       

            


        }
    }

    

