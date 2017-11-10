using CdrFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cdr.Northwind.MVCWebUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart(); 
        void SetCart(Cart cart);  // verdiğim kartı sessiona koyucak

    }
}
