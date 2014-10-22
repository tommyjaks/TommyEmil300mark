using System;
using System.Collections;
using System.ComponentModel;
using System.Net;
using System.Security.Policy;
using System.Windows;
using System.Windows.Documents;
using Logic.Readers;
using Logic.Entities;

namespace CSharpProject.Views
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
             RssReader getRssReader = new RssReader();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RssReader getRssReader = new RssReader();
            
            lbListBook.ItemsSource = getRssReader.Read(tbURL.Text);






        }

        private void lbListBook_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        
    }
}
