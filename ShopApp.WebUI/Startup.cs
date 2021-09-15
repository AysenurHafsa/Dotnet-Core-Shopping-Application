using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopApp.Business.Abstract;
using ShopApp.Business.Concrete;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EfCore;
using ShopApp.WebUI.Middlewares;

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
            services.AddScoped<IProductDal, EfCoreProductDal>(); //IProductDal çaðýrýnca MemoryProductDal gelir
            services.AddScoped<IProductService, ProductManager>(); //IProductService çaðýrýnca ProductManager gelicek
           
            services.AddScoped<ICategoryDal, EfCoreCategoryDal>(); 
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
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
        {    /*
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            
                SeedDatabase.Seed();  //SeedDatabase sýnýfý içindeki Seed metodunu çaðýrdýk (sadece geliþtirme aþamasýnda çaðýrýlmasý gereken metotdur)
                                      // app.UseMvcWithDefaultRoute();
            */
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();  //wwwroot'u dýþarýya açýyoruz
                app.CustomStaticFiles(); //middlewaare 

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    //Raute ekledik.
                    /*
                   endpoints.MapControllerRoute(
                           name: "adminProducts",
                           pattern: "admin/products",
                           defaults: new { controller = "Admin", action = "Index"}
                       );

                   endpoints.MapControllerRoute(
                      name: "products",
                      pattern: "{products}/{category?}",
                      defaults: new { controller = "shop", action = "list" }
                      ); 
                   */
                    endpoints.MapControllerRoute(
                         name: "adminProducts",
                         pattern: "admin/products/{id?}",
                         defaults: new { controller = "Admin", action = "Edit" }

                     );
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}"
                        );

                });
            }
        }
    }

