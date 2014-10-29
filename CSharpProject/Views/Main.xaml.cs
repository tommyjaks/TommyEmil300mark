
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Logic;
using Logic.Entities;
using Logic.Repositories;

using Logic.Service.Validation;
using Logic.Readers;
using Logic.Service;



namespace CSharpProject.Views
{
    public partial class MainWindow : Window
    {
       CategoryService fillCategories = new CategoryService();
        FeedService getFeeds = new FeedService();
        private ListOfFeeds skapaFeeds = new ListOfFeeds();
        private Repository<ListOfFeeds> xml2 = new Repository<ListOfFeeds>(); 

       
      
        
        public MainWindow()
        {

          
            InitializeComponent();
            
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var minUrl = tbURL.Text;
            var name = tbFlowName.Text;
            var category = cbCategory.SelectedItem.ToString();
            var urlValidate = new UrlValidator();
            urlValidate.Validate(minUrl);
            getFeeds.getRssItems(minUrl, name, category);

        
            
            





            // FeedService.getRssItems();


        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
            
        }

   

        private void cbCategory_DropDownOpened_1(object sender, EventArgs e)
        {
            cbCategory.Items.Clear();
            ComboBox cbBoxBox = cbCategory;
            fillCategories.GetCategory(cbBoxBox);
        }

        //private void FormMovieLookUp_Load_1(object sender, EventArgs e)
        //{
        //    string path = "yolo.xml";
        //ComboBox yoloBox = cbCategory;
        // string valjEnstakaNod = "ArrayOfFeedItem/FeedItem";
        //           string nodeToFill = "Title";
        //           repository.fillComboBox(yoloBox, path, valjEnstakaNod, nodeToFill);
        //}
       
         
         
       }
    }
        

        
    

