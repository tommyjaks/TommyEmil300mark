
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Logic.Entities;
using Logic.Service;
using WMPLib;
using ComboBox = System.Windows.Controls.ComboBox;
using ListView = System.Windows.Controls.ListView;
using MessageBox = System.Windows.MessageBox;


namespace CSharpProject.Views
{
   
    public partial class Details : Window
    {

        private CategoryService fillCategories = new CategoryService();
        private FeedService fillFeed = new FeedService();
        

        public Details()
        {
            InitializeComponent();

            cbCategory.Items.Clear();
            var loadxml = fillCategories.GetAllCategories();
            foreach (Category item in loadxml)
            {
                cbCategory.Items.Add(item.CategoryName);
            }

            ListView listOfFeed = listFlow;
            fillFeed.GetFeed(listOfFeed);

        }

        private void listFlow_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            listInfo.Items.Clear();
            listEpisode.Items.Clear();
            if (listFlow.SelectedItem != null)
            {
                ListView episode = listEpisode;
                string flow = listFlow.SelectedItem.ToString();
               
                fillFeed.SelectMultipleFeeds(episode, flow);
            }
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string flow = listEpisode.SelectedItem.ToString();
                fillFeed.Play(flow);

                fillFeed.EditPlayedStatus(flow);
                refreshInfoList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Du måste välja en podcast att spela upp. "+" Felmeddelande: " + ex.Message);
            }
        }

        private void cbCategory_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
                listEpisode.Items.Clear();
                ListView feed = listFlow;
                string selectItem = cbCategory.SelectedItem.ToString();

                if (cbCategory.SelectedItem != null)
                {
                    listFlow.Items.Clear();
                    fillFeed.SortMultiplePlace(feed, selectItem);
                }
          
        }

        private void listEpisode_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            refreshInfoList();
        }
        

        private void refreshInfoList()
        {
            if (listEpisode.SelectedItem != null)
            {
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

    

