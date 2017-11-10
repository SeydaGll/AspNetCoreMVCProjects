using CdrFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cdr.Northwind.MVCWebUI.ViewModels
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }  // bütün kategoriler bunun içerisinde yer alır
        public int CurrentCategory { get; set; } //görsel katmanı biraz daha özelleştirmek için kullanıcam
    }
}
