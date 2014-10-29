using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Logic.Entities;
using Logic.Repositories;
namespace Logic
{
   
   public class CategoryFiller
    {
        private Repository<Category> repository = new Repository<Category>(); 
        public void GetCategory(ComboBox Category)
        {
            string path = "Category.xml";
            
            string valjEnstakaNod = "ArrayOfCategory/Category";
            string nodeToFill = "Name";
            repository.fillComboBox(Category, path, valjEnstakaNod, nodeToFill);
        }

       public List<Category> setCategories(string tbCategory)
       {
           List<Category> categoryList = new List<Category>();
           var Category = new Category();
         
           Category.Id = new Guid();
           Category.CategoryName = tbCategory;

           categoryList.Add(Category);
           return categoryList;


       }

       public void saveCatgories(string tbCategory)
       {
           string path = "Category.xml";
           List<Category> categoryData = setCategories(tbCategory);
           repository.Save(categoryData, path);
       }

       public void editCategory(string selectedCategory, string newNode)
    {
        string xmlFile = "Category.xml";
        string chooseNode = "ArrayOfCategory/Category";
        string chooseSingleNode = "Name";
           string elementToCreate = "Name";
        

        repository.Update(xmlFile, chooseNode, chooseSingleNode, selectedCategory, elementToCreate, newNode);
    }
    }
}
