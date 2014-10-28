using System;
using System.Collections.Generic;
using System.Linq;
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
            
    }
}
