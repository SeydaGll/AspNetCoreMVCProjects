using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltersSample.Controllers
{
    [AddHeader("Author","Ahmet Bircan")]
    
    public class SampleController:Controller
    {
        public IActionResult Index()
        {
            return Content("Browser developer toolsu kullanarak header ı inceleyin!");
        }

        [ShortCircuitingResourceFilter]
        public IActionResult SomeResource()
        {
            return Content("Some Resource Content");
        }
    }
}
