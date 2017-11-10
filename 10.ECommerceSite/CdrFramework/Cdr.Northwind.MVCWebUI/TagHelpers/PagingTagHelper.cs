using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.Northwind.MVCWebUI.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]  // artık nereye pager koymak istiyosam tek yapmam gereken oraya bunu yazmak olucak
    public class PagingTagHelper:TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }// bir sayfada kaç tane satır gösterilcek

        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; } //kategorinin altında kaç tane sayfa olucak bunu bilmeliyim ki altında ona göre numara oluştruyım

        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; } // hangi kategorideysem onu burdan takip edeyim

        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }// kaçıncı sayfadayım

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div"; //razor tarafından render edildikten sonra ortaya bir div çıkıcak
            StringBuilder builder = new StringBuilder();
            builder.Append("<ul class='pagination'>");
            for (int i = 1; i <= PageCount; i++)
            {
                builder.AppendFormat("<li class='{0}'>", i == CurrentPage ? "active" : "");  // ben hangi sayfadaysam o sayfanın rengide koyu gözükecek.. bunun için li ye aktif demem lazım 
                builder.AppendFormat("<a href='/product/index?page={0}&category={1}'>{2}</a>",
                    i, CurrentCategory, i);
                builder.Append("</li>");
            }
            output.Content.SetHtmlContent(builder.ToString());
            base.Process(context, output);
        }

    }
}
