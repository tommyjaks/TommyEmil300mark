using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                CategoryName = tbCategory

            };

            createCategories.Add(newCategory);

            repository.Save(createCategories, path);


        }

        public void RemoveCategory(string categoryToManipulate)
        {
            createCategories = repository.Load(path);


            createCategories.RemoveAll(category => category.CategoryName == categoryToManipulate);

            repository.Save(createCategories, path);
        }

        public List<Category> GetAllCategories()
        {
            return repository.Load(path);
        }

        public void EditCategory(string categoryName, string newCategory)
        {
            createCategories = repository.Load(path);

            var matchingName = createCategories.FirstOrDefault(y => y.CategoryName.Equals(categoryName));
            if (matchingName != null)
            {
                matchingName.CategoryName = newCategory;
            }
            repository.Save(createCategories, path);
        }
    }
}
 



