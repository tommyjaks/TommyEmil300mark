
using Logic.Service;
using System.Windows;



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
        
            new AddFeed().Show();
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
            
        }

        private void btnChangeFeed_Click(object sender, RoutedEventArgs e)
        {
            new changeFeed().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Details().Show();
            var getRssFeedsUpdateOnSetTimerValue = new IntervalHandler.IntervalUpdateValues();
            getRssFeedsUpdateOnSetTimerValue.UpdateXmlFileWithSetIntervalForFile();
        }
       }
    }
        

        
    

