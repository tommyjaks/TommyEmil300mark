
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Logic;
using Logic.Entities;
using Logic.Repositories;
using Logic.Service.Feed;
using Logic.Service.Validation;
using Logic.Readers;
using Logic.Service;



namespace CSharpProject.Views
{
    public partial class MainWindow : Window
    {
       CategoryFiller fillCategories = new CategoryFiller();
        FeedService getFeeds = new FeedService();
        
        public MainWindow()
        {
          
            InitializeComponent();
            
            
            ComboBox cbBoxBox = cbCategory;
             fillCategories.GetCategory(cbBoxBox);
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
        

        
    

