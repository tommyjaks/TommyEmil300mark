using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Logic.Entities;
using Logic.Repositories;
namespace Logic.Service

{
   
   public class CategoryService
    {
        private Repository<ListOfCategories> repository = new Repository<ListOfCategories>();
        private ListOfCategories createCategories = new ListOfCategories();
       private string path = "Category.xml";



        public void GetCategory(ComboBox Category)
            
        {
            string path = "Category.xml";

            string valjEnstakaNod = "ListOfCategories/CategoryList/Category";
            string nodeToFill = "CategoryName";
            repository.FillComboBox(Category, path, valjEnstakaNod, nodeToFill);
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
           createCategories = repository.Load(path);
           repository.Save(createCategories, path);
          
          
         
          
               
           

           var newCategory = new Category()


           {
               Id = Guid.NewGuid(),
               CategoryName =  tbCategory
         



           };
           createCategories.AddCategory(newCategory);
           repository.Save(createCategories, path);




         
       }

       public void editCategory(string selectedCategory, string newNode)
    {
        string xmlFile = "Category.xml";
        string chooseNode = "ListOfCategories/CategoryList/Category";
        string chooseSingleNode = "CategoryName";
           string elementToCreate = "CategoryName";
        

        repository.Update(xmlFile, chooseNode, chooseSingleNode, selectedCategory, elementToCreate, newNode);
    }

       public void removeData(string selectedFeed)
       {
           string selectedNodeToRemove = "Category";
           string selectedElement = "CategoryName";

           repository.RemoveData(selectedFeed, path, selectedNodeToRemove, selectedElement);
       }
    }
}
