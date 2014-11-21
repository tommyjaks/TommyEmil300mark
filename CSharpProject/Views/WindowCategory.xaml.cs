using System;
using System.Windows;
using System.Windows.Controls;
using Logic.Entities;
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
        CategoryService fillcategoryservice = new CategoryService();
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
                fillCategory.SaveCatgories(tbText);
            }
           
        }

        private void btnEditName_Click(object sender, RoutedEventArgs e)
        {
             var validate = new UrlValidator();
             TextBox url = tbNewCategoryName;
            
            if (validate.EmptyTextBox(url))
            {
                
                var newCategoryName = tbNewCategoryName.Text;
                var categoryName = cbCategory.SelectedItem.ToString();
                fillCategory.EditCategory(categoryName, newCategoryName);
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

            //cbCategory.Items.Clear();
            var loadxml = fillCategory.GetAllCategories();
            foreach (Category item in loadxml)
            {
                cbCategory.Items.Add(item.CategoryName);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var categoryToManipulate = cbCategory.SelectedItem.ToString();
               fillcategoryservice.RemoveCategory(categoryToManipulate);
            }
            catch (Exception)
            {
                MessageBox.Show("Välj en kategori! ");
            }
        }
    }
}

