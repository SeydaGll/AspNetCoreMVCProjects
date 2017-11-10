using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdrFramework.Northwind.Entities.Concrete
{
    public class Cart  //sepet
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        public List<CartLine> CartLines { get; set; } // sepetin içindeki satırlar
        
        public decimal Total    //sepetin toplam tutarı
        {
            get { return CartLines.Sum(c => c.Product.UnitPrice * c.Quantity); }
        }
        
    }
}
