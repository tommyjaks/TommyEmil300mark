
using System.Windows;
using Logic.Service.Feed;
using Logic.Service.Validation;
using Logic.Readers;

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
            var minUrl = tbURL.Text;

            var urlValidate = new UrlValidator();
            urlValidate.Validate(minUrl);

            FeedService.getRssItems(minUrl);



        }

        private void lbListBook_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        
    }
}
