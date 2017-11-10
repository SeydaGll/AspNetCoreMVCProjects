using Cdr.Northwind.MVCWebUI.Services;
using Cdr.Northwind.MVCWebUI.ViewModels;
using CdrFramework.Northwind.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cdr.Northwind.MVCWebUI.Controllers
{
    public class CartController:Controller
    {
        private ICartSessionService _cartSessionService;
        private ICardService        _cartService; //
        private IProductService     _productService;   // eklenecek product çıkarılacak product gibi işlemlerde oraya da ulaşıcaz

        public CartController(
            ICartSessionService cartSessionService,
            ICardService        cartService,
            IProductService     productService )
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
            
        }



        public ActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);  //eklenecek olan product
            var cart = _cartSessionService.GetCart();   // cart ı alıyoruz..o anki kullanıcının kartını vermiş olucak

            _cartService.AddToCart(cart, productToBeAdded);
            _cartSessionService.SetCart(cart);  //kartı ekliyor

            TempData.Add("message", $"Your Product {productToBeAdded.ProductName} was successfully added to the cart!");  // bununla bir request lik veri taşıyabiliyruz. tempdata dan gelen veriyi henüz ekranda gösteremiyoruz
            return RedirectToAction("index", "product");


        }

        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            // CartLİstViewMOdel e  ihtiyacım var
            CartListViewModel model = new CartListViewModel {
                Cart = cart
            };
            return View(model);
        }
    }
}
