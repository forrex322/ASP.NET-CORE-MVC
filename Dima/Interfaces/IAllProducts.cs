using Dima.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Interfaces
{
    interface IAllProducts
    {
        IEnumerable<Product> Product { get; }
        IEnumerable<Product> getFavouriteProducts { get; set; }
        Product getObjectProduct(int productId);
    }
}
