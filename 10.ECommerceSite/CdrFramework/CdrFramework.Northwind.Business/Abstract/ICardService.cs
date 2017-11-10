using CdrFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CdrFramework.Northwind.Business.Abstract
{
    public interface ICardService
    {
        void AddToCart(Cart cart, Product product); // cart dediğimiz sepet.. sepet içerisine yeni satır eklerim.. hangi sepete ekliceğimi söylemem lazım(hangi kullanıcının kartı anlamında).. hangi ürünü eklicemi söylemem lazm
        void RemoveFromCart(Cart cart, int productId);
        List<CartLine> List(Cart cart);  //sepet içerisine giren her birini tespit eden sınıf
        
    }
}
