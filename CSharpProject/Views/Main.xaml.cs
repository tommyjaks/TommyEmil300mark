using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using Logic;
using Logic.Service.Validation;

namespace CSharpProject.Views
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
           
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UrlValidator urlValidate = new UrlValidator();
            urlValidate.Validate(tbURL.Text);
        }

        

    }
}
