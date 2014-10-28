
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
       CategoryFiller fillCategories = new CategoryFiller();
      RssReader yoloReader = new RssReader();
      private Repository<FeedItem> repository = new Repository<FeedItem>();

        public MainWindow()
        {
          
            InitializeComponent();
            
            
            ComboBox yoloBox = cbCategory;
             fillCategories.GetCategory(yoloBox);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var minUrl = tbURL.Text;
            string path = "yolo.xml";
            var urlValidate = new UrlValidator();
            urlValidate.Validate(minUrl);
            List<FeedItem>feedData = yoloReader.Read(minUrl);
           repository.Save(feedData, path);
            
            





            // FeedService.getRssItems();


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
        

        
    

