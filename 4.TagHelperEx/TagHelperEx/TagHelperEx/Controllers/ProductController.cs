using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagHelperEx.Models;

namespace TagHelperEx.Controllers
{
    public class ProductController:Controller
    {
        static List<Product> pList = new List<Product>
        {
            new Product{ ProductId=1, Name="Iphone 7"},
            new Product{ ProductId=2, Name="Iphone 6"},
            new Product{ ProductId=3, Name="Iphone 5"},
            new Product{ ProductId=4, Name="Iphone 4"},
        };

        public IActionResult Index()
        {
            return View(pList);  // index viewi benim için bütün productları listelicek..
        }

        [Route("Urun/Detaylari/{id?}")]  //Attribute Routing
        public IActionResult Detail(int id)
        {
            return View(pList.FirstOrDefault(q => q.ProductId == id));
        }
        [HttpGet] // yazmana gerek yok.. varsayılan olarak vardır..
        public IActionResult Create()  //iki tane create actionı yazdık.. birtane create viewi için 2 tane create action tanımladık. biri form u göstermek için(bu cshtml i göstermek için),
        {                                // ikinci action ise bu create cshtml içerisindeki formun post ettiği zaman benim o gelen post talebeni karşılayacak olan action ım
            return View();
        }

        [HttpPost] // post isteği gönderilecek
        public IActionResult Create(Product model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Modeliniz gerekli kurallara uymuyor!");
                return View(model);
            }
               
            pList.Add(model);
            return RedirectToAction("index");
        }

    }
}
// normalde repository ın götürüp arka tarafta veritabanına ekler