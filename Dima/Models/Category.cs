using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Models
{
    public class Category
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string desccription { get; set; }
        public List<Product> products { get; set; } 
    }
}
