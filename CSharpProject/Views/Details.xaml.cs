using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Logic;
using System.Xml.XPath;
using Logic.Service;
using ComboBox = System.Windows.Controls.ComboBox;
using ListView = System.Windows.Controls.ListView;

namespace CSharpProject.Views
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {

        private CategoryService fillCategories = new CategoryService();
    //  private FeedListFiller fillFeed = new FeedListFiller();

        public Details()
        {
            InitializeComponent();

            ComboBox cbBoxBox = cbCategory;
            fillCategories.GetCategory(cbBoxBox);

            ListView listOfFeed = listFlow;
        //  fillFeed.GetFeedItem(listOfFeed);

        }

        private void listFlow_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
              listEpisode.Items.Clear();
              string flow = listFlow.SelectedItem.ToString();
              var doc = new XmlDocument();
              doc.Load("Feed.xml");
              XmlNodeList selectedNodes = doc.SelectNodes("ArrayOfFeedItem");
              
              foreach (XmlNode node in selectedNodes)
              {
                  if (node.SelectSingleNode("Name").InnerText == flow)
                  {
                      XmlNode feedItem = node.SelectSingleNode("FeedItem");
                      for (int i = 0; i < feedItem.ChildNodes.Count; i++)
                      {
                          listEpisode.Items.Add(feedItem.ChildNodes.Item(i).LastChild.InnerText);
                      }
                  }
              }
                

              
                
        }

       

            //public void SelectFeed()
            //{
            //    string flow = listFlow.SelectedIndex.ToString();

            //    var xdoc = XDocument.Load("Feed.xml");
            //    var type = (string)xdoc.XPathSelectElement("//FeedItem[Name="+flow+"]/Title");

            //    listEpisode.Items.Add(type);
            //}


        }
    }

    

