using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Security.Policy;
using System.Windows;
using System.Windows.Documents;
using Logic.Readers;
using Logic.Entities;
using Logic.Service.Validation;

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
            UrlValidator urlValidate = new UrlValidator();
            urlValidate.Validate(tbURL.Text);

            




        }

        private void lbListBook_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        
    }
}
