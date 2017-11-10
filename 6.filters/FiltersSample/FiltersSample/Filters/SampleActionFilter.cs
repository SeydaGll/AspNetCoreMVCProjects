using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltersSample.Filters
{
    public class SampleActionFilter : IActionFilter// senkron bir filtre için örnek
    {
        

        public void OnActionExecuting(ActionExecutingContext context)
        {
           //action execute edilmeden önce yapacaklarım
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //action execute edildikten sonra yapacaklarım
        }

       
    }
}
