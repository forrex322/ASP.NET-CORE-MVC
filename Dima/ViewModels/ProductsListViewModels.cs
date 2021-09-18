using Dima.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.ViewModels
{
    public class ProductsListViewModels
    {
        public IEnumerable<Product> allProducts { get; set; }

        public string currentCategory { get; set; }
    }
}
