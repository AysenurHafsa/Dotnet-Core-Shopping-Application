using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopApp.Business.Abstract;
using ShopApp.Business.Concrete;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            /* sadece buradan ,bu metotda  IProduct ile bu ikisi çaðýrýlabilir
            // IProduct, EFCoreProductDal 
            // IProduct, MySqlProductDal 
            */
            //
            services.AddScoped<IProductDal, MemoryProductDal>(); //IProductDal çaðýrýnca MemoryProductDal gelir
            services.AddScoped<IProductService, ProductManager>(); //IProductService çaðýrýnca ProductManager gelicek

            services.AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0) ;
            //MVC Fremawork unu uygulamaya ekliyor ve versiyonlar arttýðý zaman versiyon uyumlluðu için gerekli kodlarý ekliyoruz.
        }
        /*
        private void SetCompatibilityVersion(CompatibilityVersion compatibilityVersion)
        {
            throw new NotImplementedException();
        }
        */
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           // app.UseMvcWithDefaultRoute();


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute(
                      name: "default",
                      pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
