using Dima.Interfaces;
using Dima.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Mocks
{
    public class MockCategory : IProductsCategory
    {
        public IEnumerable<Category> AllCategories 
        {
            get
            {
                return new List<Category>
                {
                    new Category {categoryName = "Iphone", desccription = "This is smartphone" },
                    new Category {categoryName = "Macbook", desccription = "This is notebook"}
                };
            }
        }
    }
}
