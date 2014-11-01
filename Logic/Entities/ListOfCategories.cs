using System;
using System.Collections.Generic;


namespace Logic.Entities
{
    public class ListOfCategories : List
    {
        public new Guid Id { get; set; }
        
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
