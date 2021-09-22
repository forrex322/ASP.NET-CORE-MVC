using Dima.Interfaces;
using Dima.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Repository
{
    public class ProductRepository : IAllProducts
    {

        private readonly AppDBContent appDBContent;

        public ProductRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Product> Products => appDBContent.Product.Include(c => c.Category);

        public IEnumerable<Product> getFavouriteProducts => appDBContent.Product.Where(p => p.isFavourive).Include(c => c.Category);

        public Product getObjectProduct(int productId) => appDBContent.Product.FirstOrDefault(p => p.id == productId);
        
    }
}
