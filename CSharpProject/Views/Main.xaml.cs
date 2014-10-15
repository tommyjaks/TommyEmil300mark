using System;
using System.ComponentModel;
using System.Net;
using System.Windows;

namespace CSharpProject.Views
{
    public partial class MainWindow : Window
    {
        WebClient wc = new WebClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wc.DownloadFileCompleted += new AsyncCompletedEventArgs(FileWebResponse);
            var url= new Uri(tbURL.Text);
            wc.DownloadFileAsync(url, tbFlow.Text);
        }

        
    }
}
