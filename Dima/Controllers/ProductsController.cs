using Dima.Interfaces;
using Dima.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAllProducts _allProducts;
        private readonly IProductsCategory _allCategories;

        public ProductsController(IAllProducts iAllProduct, IProductsCategory iProductsCategory)
        {
            _allProducts = iAllProduct;
            _allCategories = iProductsCategory;
        }

        public ViewResult List()
        {
            ProductsListViewModels obj = new ProductsListViewModels();
            obj.allProducts = _allProducts.Products;
            obj.currentCategory = "Товары";

            return View(obj);
        }

    }
}
