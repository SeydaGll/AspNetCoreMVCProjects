using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using CdrFramework.Northwind.Business.Abstract;
using CdrFramework.Northwind.Business.Concrete;
using CdrFramework.Northwind.DataAccess.Abstract;
using CdrFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Cdr.Northwind.MVCWebUI.Services;

namespace Cdr.Northwind.MVCWebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService,ProductManager>();  //scoped request başına oluşturulurken; singleton uygulama yaşam döngüsü boyunca sadece bir nesne oluşturmasını sağlıyor
            services.AddScoped<IProductDal, EFProductDal>();  //bunu isteyen productmanager dır. bu IproductDal ister
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EFCategoryDal>();
            services.AddScoped<ICartSessionService, CartSessionService>();
            services.AddScoped<ICardService,CartService>();

            services.AddSession();  // bağımlılığımızı eklememiz gerekiyor
            services.AddDistributedMemoryCache();  // session nerde tutulacak olayı vs buna bağımlı oluyor


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();// uygulama yaşam döngüsü boyunca sadece bir servis 
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())  //hata yaparsak buradan görücez
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute(); // varsayılan route la beraber çalışsın. default controller şudur diye kullanıyoduk. bu şekilde olabilir
            //kendi route mızı kullanalım

            //uygulamanın middleware ine de session ı eklemem gerekiyor
            app.UseSession();
            app.UseMvc(ConfigureRoutes);

        }

        private void ConfigureRoutes(IRouteBuilder routebuilder) //route tanımlamanın farklı yöntemi
        {
            //route ı elle tanımlayalım
            routebuilder.MapRoute("Default", "{controller=Product}/{action=index}/{id?}");
        }
            }
}
