using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewComponenets
{
    public class SliderViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            List<string> sliderList = new List<string>
            {
                "/images/banner1.svg",
                "/images/banner2.svg",
                "/images/banner3.svg",
                "/images/banner4.svg",

            };
            return View(sliderList);
        }
    }
}
