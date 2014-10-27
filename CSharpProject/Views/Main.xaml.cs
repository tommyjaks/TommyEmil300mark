
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Logic.Entities;
using Logic.Repositories;
using Logic.Service.Validation;
using Logic.Readers;



namespace CSharpProject.Views
{
    public partial class MainWindow : Window
    {
      RssReader yoloReader = new RssReader();
      private Repository<FeedItem> repository = new Repository<FeedItem>();

        public MainWindow()
        {
          
            InitializeComponent();
            string path = "yolo.xml";
            ComboBox yoloBox = cbCategory;
            string valjEnstakaNod = "ArrayOfFeedItem/FeedItem";
            string nodeToFill = "Title";
            repository.fillComboBox(yoloBox, path, valjEnstakaNod, nodeToFill);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var minUrl = tbURL.Text;
            string path = "FeedItems.Xml";
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
        

        
    

