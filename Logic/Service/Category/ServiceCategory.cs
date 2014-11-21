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
       public Repository<Category> repository = new Repository<Category>();
       public List<Category> createCategories = new List<Category>();
      
       private string path = "Category.xml";



        public void GetCategory(ComboBox Category)
            
        {
            string path = "Category.xml";

            string valjEnstakaNod = "ListOfCategories/CategoryList/Category";
            string nodeToFill = "CategoryName";
            repository.FillSomething(Category, path, valjEnstakaNod, nodeToFill);
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

       public void SaveCatgories(string tbCategory)
       {
           createCategories = repository.Load(path);
           repository.Save(createCategories, path);
           
           






           var newCategory = new Category()


           {
               Id = Guid.NewGuid(),
               CategoryName =  tbCategory
         



           };
           
           createCategories.Add(newCategory);
           
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

       public List<Category> GetAllCategories()
       {
           return repository.Load(path);
       }

       public void ManiPulateCategory(string categoryToRemove)
       {
           createCategories = repository.Load(path);

           
           foreach (Category item in createCategories)
           {
              
               }
           }
       }
    }


