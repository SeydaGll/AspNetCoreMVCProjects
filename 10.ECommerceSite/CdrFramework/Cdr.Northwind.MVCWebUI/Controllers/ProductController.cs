using Cdr.Northwind.MVCWebUI.ViewModels;
using CdrFramework.Northwind.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace Cdr.Northwind.MVCWebUI.Controllers
{
    public class ProductController:Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index(int page=1,int category=0) //page istiyorum ve varsayılan değerini 1 atıyorum
        {
            int pageSize = 10;//bir sayfada kaç ürün göstermek istiyorum.10 olsun
            var products = _productService.GetByCategoryId(category);
            ProductListViewModel model = new ProductListViewModel
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount=(int) Math.Ceiling(products.Count/(double)pageSize),  //Math.Ceiling  5 tane  pager butonu olsun diye yaptık.. yukarı yuvarlıcak
                PageSize=pageSize,
                CurrentCategory=category,
                CurrentPage=page
            };
            return View(model);
        }

        public void Session()
        {
            HttpContext.Session.SetString("userName", "abircan");
            HttpContext.Session.SetInt32("plakaKodu", 07);

            var userName= HttpContext.Session.GetString("userName");
            var plakaKodu=  HttpContext.Session.GetInt32("plakaKodu");
        }
    }
}
