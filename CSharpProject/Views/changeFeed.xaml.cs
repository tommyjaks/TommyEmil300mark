using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Logic.Service;

namespace CSharpProject.Views
{
    /// <summary>
    /// Interaction logic for changeFeed.xaml
    /// </summary>
    public partial class changeFeed : Window
    {
        CategoryService serviceCategory = new CategoryService();
        FeedService serviceFeeds = new FeedService();

        public changeFeed()
        {
            InitializeComponent();
        }

       

        private void cbCategories_DropDownOpened(object sender, EventArgs e)
        {
            cbCategories.Items.Clear();
            ComboBox cbBoxBox = cbCategories;
            serviceCategory.GetCategory(cbBoxBox);
        }

        private void cbFeed_DropDownOpened(object sender, EventArgs e)
        {
            cbFeed.Items.Clear();
            ComboBox cbBox = cbFeed;
            serviceFeeds.SetFeed(cbBox);
        }

        private void btnEditCategory_Click(object sender, RoutedEventArgs e)
        {
            var selectedFeed = cbFeed.SelectedItem.ToString();
            var newName = tbName.Text;
            var newUrl = tbUrl.Text;
            var newCategory = cbCategories.SelectedItem.ToString();

            serviceFeeds.getFeedUpdateInfo(selectedFeed, newName, newUrl, newCategory);
        }

        private void btnRemoveFeed_Click(object sender, RoutedEventArgs e)
        {
            var selectedFeedToRemove= cbFeed.SelectedItem.ToString();
           
            serviceFeeds.GetFeedToRemove(selectedFeedToRemove);
        }
    }
}
