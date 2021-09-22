using Dima.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content) 
        {
            if (!content.Category.Any()) 
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Product.Any())
            {
                content.AddRange(
                new Product
                {
                    name = "Iphone 13",
                    shortDescription = "This is iphone!",
                    longDescription = "This is the best iphone ever!",
                    img = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-select-2021?wid=470&amp;hei=556&amp;fmt=jpeg&amp;qlt=95&amp;.v=1631046287000.jpg",
                    isFavourive = true,
                    price = 1200,
                    available = true,
                    Category = Categories["Iphone"]
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
                    Category = Categories["Macbook"]
                }   
                );
            }

            content.SaveChanges();

        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category {categoryName = "Iphone", desccription = "This is smartphone" },
                        new Category {categoryName = "Macbook", desccription = "This is notebook"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach(Category el in list)
                    {
                        category.Add(el.categoryName, el);
                    }
                }
                return category;
            }
        }
    }
}
