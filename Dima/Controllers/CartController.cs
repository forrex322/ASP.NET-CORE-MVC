using Dima.Interfaces;
using Dima.Models;
using Dima.Repository;
using Dima.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Controllers
{
    public class CartController : Controller
    {
        private readonly IAllProducts _productRepository;
        private readonly WorkOfCart _workOfCart;

        public CartController(IAllProducts productRepository, WorkOfCart workOfCart)
        {
            _productRepository = productRepository;
            _workOfCart = workOfCart;
        }

        public ViewResult Index()
        {
            var items = _workOfCart.getItems();
            _workOfCart.listOfCart = items;

            var obj = new CartViewModel
            {
                workOfCart = _workOfCart
            };

            return View(obj);

        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _productRepository.Products.FirstOrDefault(i => i.id == id);
            
            if (item != null)
            {
                _workOfCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

    }
}
