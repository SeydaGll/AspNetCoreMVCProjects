using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltersSample.Filters
{
    public class AddHeaderWithFactoryAttribute : Attribute, IFilterFactory
    {
        


        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new InternalAddHeaderFilter();
        }

        private class InternalAddHeaderFilter : IResultFilter
        {
            public void OnResultExecuted(ResultExecutedContext context)
            {

            }

            public void OnResultExecuting(ResultExecutingContext context)
            {
                context.HttpContext.Response.Headers.Add("Internal", new string[] { "Header Added" });
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
