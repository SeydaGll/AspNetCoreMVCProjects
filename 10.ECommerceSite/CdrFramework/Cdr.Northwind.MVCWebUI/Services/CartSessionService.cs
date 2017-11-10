using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CdrFramework.Northwind.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Cdr.Northwind.MVCWebUI.ExtensionMethods;

namespace Cdr.Northwind.MVCWebUI.Services
{
    public class CartSessionService : ICartSessionService  // oanda bana istek yapan kullanıcını session ına erişmem lazım
    {
        private IHttpContextAccessor _httpContextAccessor;
        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Cart GetCart()  // sessiondan cart ı alıcak bize vericek
        {
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");  //  cart ın sessionda olup olmadığını kontrol ediyoruz. kullanıcının session ında cart key inin karşılığında bir değer var mı yok mu o kontrol edilir
            if (cartToCheck==null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart());  // boş sepet oluşturma
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return cartToCheck;

        }

        public void SetCart(Cart cart) // session ın içerisine kartı koyucak
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);  // orda bir kart varsa sana yeni gelen kartı onun üzerine yazmış oluyosun
        }
    }
}
