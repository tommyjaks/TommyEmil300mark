using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ComboBox = System.Windows.Controls.ComboBox;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;
using Logic.Service;
using Logic.Service.Validation;

namespace CSharpProject.Views
{
    /// <summary>
    /// Interaction logic for AddFeed.xaml
    /// </summary>
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
            if (cbCategory.SelectedItem != null)
            {
                var minUrl = tbURL.Text;

                TextBox flowName = tbFlowName;
                var name = tbFlowName.Text;
                var category = cbCategory.SelectedItem.ToString();
                var urlValidate = new UrlValidator();

                if (urlValidate.Validate(minUrl) &&
                    urlValidate.EmptyTextBox(flowName) == true)
                {
                    try
                    {
                        getFeeds.getRssItems(minUrl, name, category);
                        MessageBox.Show("Podcast tillagd!");
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
            ComboBox cbBoxBox = cbCategory;
            fillCategories.GetCategory(cbBoxBox);
        }
    }
}
