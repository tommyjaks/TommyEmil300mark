﻿
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            string flow = listEpisode.SelectedItem.ToString();
            fillFeed.Play(flow);
           
            fillFeed.EditPlayedStatus(flow);
            refreshInfoList();

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

    

