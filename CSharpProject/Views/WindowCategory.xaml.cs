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
using Logic;
using Logic.Service;


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

          
            var tbText = tbCategory.Text;
            fillCategory.saveCatgories(tbText);
        }

        private void btnEditName_Click(object sender, RoutedEventArgs e)
        {
            
            FeedService changeXmlCategory = new FeedService();
            var newCategoryName = tbNewCategoryName.Text;
            var selectedItem = cbCategory.SelectedItem.ToString();

            fillCategory.editCategory(selectedItem, newCategoryName);
            changeXmlCategory.EditCategoryInFeedXmlFile(selectedItem, newCategoryName);
            cbCategory.Items.Clear();


            
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
           
            ComboBox cbBoxBox = cbCategory;
            fillCategory.GetCategory(cbBoxBox);
            string selected = cbCategory.Text;
            tbNewCategoryName.Text = selected;

        }
    }
}

