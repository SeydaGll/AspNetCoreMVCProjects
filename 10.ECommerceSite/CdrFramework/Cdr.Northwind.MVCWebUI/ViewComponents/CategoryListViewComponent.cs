﻿using Cdr.Northwind.MVCWebUI.ViewModels;
using CdrFramework.Northwind.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cdr.Northwind.MVCWebUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()  //uyandırmak gibi anlmaı var
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryService.GetAll(),
                CurrentCategory=Convert.ToInt32(HttpContext.Request.Query["category"])

            };
            return View(model);
        }
    }
}
