﻿using CdrFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cdr.Northwind.MVCWebUI.ViewModels
{
    public class ProductListViewModel  // bu sınıf içerisinde ben neyi gösterceksem sadece onu taşısın
    {
        public List<Product> Products { get; set; }
        public int CurrentCategory { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }

    }
}
