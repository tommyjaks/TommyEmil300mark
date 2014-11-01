using System;
using System.Windows;
using System.Windows.Controls;
using Logic.Service;
using Logic.Service.Validation;


namespace CSharpProject.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        CategoryService fillCategory = new CategoryService();
        public Window1()
        {
            InitializeComponent();
            
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
           
             var validate = new UrlValidator();
            TextBox category = tbCategory;
          
            if (validate.EmptyTextBox(category))
            {
                var tbText = tbCategory.Text;
                fillCategory.saveCatgories(tbText);
            }
        }

        private void btnEditName_Click(object sender, RoutedEventArgs e)
        {
               var validate = new UrlValidator();
             TextBox url = tbNewCategoryName;
            
            if (validate.EmptyTextBox(url))
            {
                FeedService changeXmlCategory = new FeedService();
                var newCategoryName = tbNewCategoryName.Text;
                var selectedItem = cbCategory.SelectedItem.ToString();

                fillCategory.editCategory(selectedItem, newCategoryName);
                changeXmlCategory.EditCategoryInFeedXmlFile(selectedItem, newCategoryName);
                cbCategory.Items.Clear();
            }



        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {




            if (cbCategory.SelectedIndex == -1)
            {
                tbNewCategoryName.Text = string.Empty;
            }
            else
            {
                tbNewCategoryName.Text = cbCategory.SelectedItem.ToString();
            }
        }

        private void cbCategory_DropDownOpened(object sender, EventArgs e)
        {
            cbCategory.Items.Clear();
           
            ComboBox cbBoxBox = cbCategory;
            fillCategory.GetCategory(cbBoxBox);
            string selected = cbCategory.Text;
            tbNewCategoryName.Text = selected;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategoryToRemove = cbCategory.SelectedItem.ToString();
            fillCategory.removeData(selectedCategoryToRemove);
        }
    }
}

