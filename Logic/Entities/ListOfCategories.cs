using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class ListOfCategories : IEntity
    {
        public Guid Id { get; set; }
        public List<Category> Kategori { get; set; }

        public ListOfCategories()
        {
            Kategori = new List<Category>();
        }

        public void AddCategory(Category category)
        {
           Kategori.Add(category);
        }
    }

}
