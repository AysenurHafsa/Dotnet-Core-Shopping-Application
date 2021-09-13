using Microsoft.AspNetCore.Mvc;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    public class AdminController : Controller
    {
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

        public IActionResult CreateProduct(Product entity)
        {
            return Redirect("Index"); //kullanıcıyı yeni bir sayfaya:index e gönderiyoruz
        }
    }
}
