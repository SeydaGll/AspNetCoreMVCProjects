using CdrFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using CdrFramework.Northwind.Entities.Concrete;

namespace CdrFramework.Northwind.Business.Concrete
{
    public class CartService : ICardService
    {
        public void AddToCart(Cart cart, Product product)  //hangi kartın içine ekleyeceğimi ve hangi ürünü ekleyeceğimi göndermişlerdi. bana gelen kartın içerisinden cartline lar var
        {
            // karta ekleme işlemi
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);  // gelene eşitse bana o satırı var.. aynı üründen cartta varsa sorgusu yaptık
            if (cartLine!=null)
            {
                cartLine.Quantity++;
                return;
            }

            cart.CartLines.Add(new CartLine { Product = product, Quantity = 1 });
        }

       
        public void RemoveFromCart(Cart cart, int productId)  // carttan nasıl silicez
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId)); // kartın içerisindeki satırlardan o satırın içinde productıd si bana parametre olarak gelen productıd sine eşit olan satırı sil demiş olduk.
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

    }
}
