using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class ListOfCategories : IEntity
    {
        public Guid Id { get; set; }
        
        public List<Category> CategoryList { get; set; }
        

        public ListOfCategories()
        {
          CategoryList = new List<Category>();
        }

        public void AddCategory(Category category)
        {
            CategoryList.Add(category);
        }
    }

}
