using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMVCProject.Models;
using AspNetCoreMVCProject.ViewModels;

namespace AspNetCoreMVCProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Product> pList = new List<Product>
            {
                new Product{ Name="iphone 7", Price=3500, Stock= 55},
                new Product{ Name="iphone 8", Price=4000, Stock=10},
                new Product{ Name="MacBook", Price=1500, Stock=0}
            };

            
            List<ProductViewModel> pvmList = new List<ProductViewModel>();
            foreach (var item in pList)
            {
                ProductViewModel pvm = new ProductViewModel()
                {
                    Name = item.Name,
                    Price = item.Price,

                };
                if (item.Stock==0)
                pvm.Stock = "Tükendi";
                else if (item.Stock<20)
                pvm.Stock = "az kaldı";
                else
                pvm.Stock = "Stokta";
                pvmList.Add(pvm);
                
            }
            
            
            return View(pvmList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
