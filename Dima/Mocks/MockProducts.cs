using Dima.Interfaces;
using Dima.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Mocks
{
    public class MockProducts : IAllProducts
    {
        private readonly IProductsCategory _categoryPorducts = new MockCategory();

        public IEnumerable<Product> Products 
        {
            get
            {
                return new List<Product>
                {
                new Product 
                { 
                    name = "Iphone 13", 
                    shortDescription = "This is iphone!", 
                    longDescription = "This is the best iphone ever!", 
                    img = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-select-2021?wid=470&amp;hei=556&amp;fmt=jpeg&amp;qlt=95&amp;.v=1631046287000.jpg", 
                    isFavourive = true, 
                    price = 1200, 
                    available = true, 
                    Category = _categoryPorducts.AllCategories.First() 
                },
                new Product
                {
                    name = "Macbook Pro 2019",
                    shortDescription = "This is macbook!",
                    longDescription = "This is the best macbook ever!",
                    img = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/mbp16touch-space-select-201911_GEO_RU?wid=452&hei=420&fmt=jpeg&qlt=95&.v=1572654989311.jpg",
                    isFavourive = true,
                    price = 2200,
                    available = true,
                    Category = _categoryPorducts.AllCategories.Last()
                }
                };
            }
        }
        public IEnumerable<Product> getFavouriteProducts { get; set; }

        public Product getObjectProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
