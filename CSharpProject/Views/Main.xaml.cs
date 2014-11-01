
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using Logic;
using Logic.Entities;
using Logic.Repositories;

using Logic.Service.Validation;
using Logic.Readers;
using Logic.Service;
using ComboBox = System.Windows.Controls.ComboBox;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;


namespace CSharpProject.Views
{
    public partial class MainWindow : Window
    {
       CategoryService fillCategories = new CategoryService();
        FeedService getFeeds = new FeedService();
        private ListOfFeeds skapaFeeds = new ListOfFeeds();
        private Repository<ListOfFeeds> xml2 = new Repository<ListOfFeeds>(); 

       
      
        
        public MainWindow()
        {

          
            InitializeComponent();
            
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(cbCategory.SelectedItem != null){
            var minUrl = tbURL.Text;
            //TextBox url = tbURL;
            //TextBox flowName = tbFlowName;
            var name = tbFlowName.Text;
            var category = cbCategory.SelectedItem.ToString();
            var urlValidate = new UrlValidator();
            urlValidate.Validate(minUrl);
          
            getFeeds.getRssItems(minUrl, name, category);
                MessageBox.Show("Podcast tillagd!");
            }
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
            
        }

   

        private void cbCategory_DropDownOpened_1(object sender, EventArgs e)
        {
            cbCategory.Items.Clear();
            ComboBox cbBoxBox = cbCategory;
            fillCategories.GetCategory(cbBoxBox);
        }

        private void btnChangeFeed_Click(object sender, RoutedEventArgs e)
        {
            new changeFeed().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Details().Show();
        }
       }
    }
        

        
    

