
using System.Windows;
using Logic.Service.Validation;
using Logic.Readers;

namespace CSharpProject.Views
{
    public partial class MainWindow : Window
    {
        RssReader getRssFeed = new RssReader();

        public MainWindow()
        {
           
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var minUrl = tbURL.Text;

            var urlValidate = new UrlValidator();
            urlValidate.Validate(minUrl);





        }

        private void lbListBook_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        
    }
}
