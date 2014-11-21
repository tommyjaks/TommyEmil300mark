
using System;
using System.Windows;
using Logic.Entities;
using Logic.Service;
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
        
       
           
            var loadxml2 = fillCategories.GetAllCategories();
            foreach (Category item in loadxml2)
            {
                listFlow.Items.Add(item.CategoryName);
            }
        

            //ListView listOfFeed = listFlow;
            //fillFeed.GetFeed(listOfFeed);

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
                var load = fillFeed.SelectSingleFeed(chooseFirstDesc, selectListItem, compareWithNode, selectNode);
                feed.Items.Add(load);
                string selectNode2 = "Uppspelad";
                var load2 = fillFeed.SelectSingleFeed(chooseFirstDesc, selectListItem, compareWithNode, selectNode2);
                feed.Items.Add(load2);
            }
        }

        private void cbCategory_DropDownOpened(object sender, EventArgs e)
        {
            
            cbCategory.Items.Clear();
            var loadxml = fillCategories.GetAllCategories();
            foreach (Category item in loadxml)
            {
                cbCategory.Items.Add(item.CategoryName);
            }
        
        }

  



        }
    }

    

