
using System;
using System.Collections.Generic;
using System.Windows;
using Logic.Entities;

using Logic.Service.Validation;
using Logic.Readers;



namespace CSharpProject.Views
{
    public partial class MainWindow : Window
    {
      RssReader yoloReader = new RssReader();
       

        public MainWindow()
        {
           
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var minUrl = tbURL.Text;

            var urlValidate = new UrlValidator();
            urlValidate.Validate(minUrl);
            
            List<FeedItem>feedData = yoloReader.Read(minUrl);
            Console.WriteLine(feedData);

             

            var save = new save




            // FeedService.getRssItems();


        }

        private void lbListBook_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        
    }
}
