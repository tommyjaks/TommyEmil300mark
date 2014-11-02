using System;
using System.Windows;
using System.Windows.Forms;
using Logic.Service;
using Logic.Service.Validation;
using ComboBox = System.Windows.Controls.ComboBox;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;

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

            var validate = new UrlValidator();
            TextBox url = tbUrl;
            TextBox name = tbName;
            try
            {
                if (validate.EmptyTextBox(url) && validate.EmptyTextBox(name))
                {
                    var selectedFeed = cbFeed.SelectedItem.ToString();
                    var newName = tbName.Text;
                    var newUrl = tbUrl.Text;
                    var newCategory = cbCategories.SelectedItem.ToString();
                    var newUpdateinterval = cbInterval.SelectedItem.ToString();
                    serviceFeeds.getFeedUpdateInfo(selectedFeed, newName, newUrl, newUpdateinterval, newCategory);
                    MessageBox.Show("Flödet har ändrats");
                    tbName.Clear();
                    tbUrl.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Du måste välja en feed att ändra. Felmeddelande: " + ex.Message);
            }
        }

        private void btnRemoveFeed_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                var selectedFeedToRemove = cbFeed.SelectedItem.ToString();
                    serviceFeeds.GetFeedToRemove(selectedFeedToRemove);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Du måste välja en feed att ta bort. Felmeddelande: " + ex.Message);
            }
        }

        private void cbInterval_DropDownOpened(object sender, EventArgs e)
        {
            cbInterval.Items.Clear();
            cbInterval.Items.Add("10");
            cbInterval.Items.Add("30");
            cbInterval.Items.Add("60");
        }
    }
}
