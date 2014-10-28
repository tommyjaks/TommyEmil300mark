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

namespace CSharpProject.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
             CategoryFiller fillCategory = new CategoryFiller();
            ComboBox cbBoxBox = cbCategory;
            fillCategory.GetCategory(cbBoxBox);
            string selected = cbCategory.Text;
            tbNewCategoryName.Text = selected;
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {

            CategoryFiller fillCategory = new CategoryFiller();
            var tbText = tbCategory.Text;
            fillCategory.saveCatgories(tbText);
        }

        private void btnEditName_Click(object sender, RoutedEventArgs e)
        {
                CategoryFiller fillCategory = new CategoryFiller();
          var newCategoryName =  tbNewCategoryName.Text;
         //   var selectedItem = cbCategory.SelectedItem.ToString();

            fillCategory.editCategory();
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            if (cbCategory.SelectedIndex == -1) {
    tbNewCategoryName.Text = string.Empty;
  } else {
    tbNewCategoryName.Text = cbCategory.SelectedItem.ToString();
  }
}  
        }
    }

