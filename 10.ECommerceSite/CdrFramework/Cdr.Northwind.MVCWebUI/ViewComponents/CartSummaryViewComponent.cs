using Cdr.Northwind.MVCWebUI.Services;
using Cdr.Northwind.MVCWebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cdr.Northwind.MVCWebUI.ViewComponents
{
    public class CartSummaryViewComponent:ViewComponent
    {
        private ICartSessionService _cartSessionService;
        public CartSummaryViewComponent(ICartSessionService cartSessionService)
        {
            _cartSessionService = cartSessionService;
        }


        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel
            {
                //bana kart bilgisi kim verir
                Cart = _cartSessionService.GetCart()
            };
            return View(model);
        }
    }
}
