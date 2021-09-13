using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Entities;
using ShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]     //form u getiricek metot(parametresiz)

        public IActionResult CreateProduct( )  
        {
            return View();
        }

        [HttpPost]   //post metodu

        public IActionResult CreateProduct(ProductModel model)  //sayfadan model aldıyoruz
        {
            var entity = new Product()
            {
                //product icerisindeki degerleri tanımladık
                Name = model.Name,
                Price = model.Price,
                Description =model.Description,
                ImageUrl =model.ImageUrl
            };
            _productService.Create(entity); //kayıt islemi yapıyor

            return Redirect("Index"); //kullanıcıyı yeni bir sayfaya:index e gönderiyoruz
        }
    }
}
