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



        public void GetCategory(ComboBox Category)
            
        {
            string path = "Category.xml";

            string valjEnstakaNod = "ListOfCategories/CategoryList/Category";
            string nodeToFill = "CategoryName";
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
           string xmlFilPathpath = "Category.xml";
            createCategories = repository.Load(xmlFilPathpath);
          
           repository.Save(createCategories, xmlFilPathpath);
          
               
           

           var newCategory = new Category()


           {
               Id = Guid.NewGuid(),
               CategoryName =  tbCategory
         



           };
           createCategories.AddCategory(newCategory);
           repository.Save(createCategories, xmlFilPathpath);




         
       }

       public void editCategory(string selectedCategory, string newNode)
    {
        string xmlFile = "Category.xml";
        string chooseNode = "ListOfCategories/CategoryList/Category";
        string chooseSingleNode = "CategoryName";
           string elementToCreate = "CategoryName";
        

        repository.Update(xmlFile, chooseNode, chooseSingleNode, selectedCategory, elementToCreate, newNode);
    }

       public void removeData(string choosenObj, string cbItem)
       {
           string path = "Category.xml";
           string selectedNodeToRemove = "CategoryName";
           repository.RemoveData(choosenObj, path, selectedNodeToRemove, cbItem);
       }
    }
}
