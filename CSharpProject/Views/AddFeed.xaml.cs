using System;
using System.Windows;
using Logic.Entities;
using ComboBox = System.Windows.Controls.ComboBox;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;
using Logic.Service;
using Logic.Service.Validation;

namespace CSharpProject.Views
{

    public partial class AddFeed : Window
    {
        CategoryService fillCategories = new CategoryService();
        FeedService getFeeds = new FeedService();
        
        public AddFeed()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbCategory.SelectedItem != null && cbInterval.SelectedItem != null)
            {
                var minUrl = tbURL.Text;

                TextBox flowName = tbFlowName;
                var name = tbFlowName.Text;
                var category = cbCategory.SelectedItem.ToString();
                var urlValidate = new UrlValidator();
                var selectedUpdateInterval = cbInterval.SelectedItem.ToString();
                if (urlValidate.Validate(minUrl) &&
                    urlValidate.EmptyTextBox(flowName) == true)
                {
                    try
                    {
                        getFeeds.GetRssItems(minUrl, name,category,selectedUpdateInterval);
                        MessageBox.Show("Podcast tillagd!");
                        tbFlowName.Clear();
                        tbURL.Clear();
                    }
                    catch (Exception ez)
                    {
                        MessageBox.Show("Din url verkar inte gå att ladda. Felmeddelande:" + ez.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Du måste ange en kategori för att spara!");
            }
        }
        private void cbCategory_DropDownOpened_1(object sender, EventArgs e)
        {
            cbCategory.Items.Clear();
            var loadxml = fillCategories.GetAllCategories();
            foreach (Category item in loadxml)
            {
                cbCategory.Items.Add(item.CategoryName);
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
