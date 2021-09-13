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

        [HttpGet]

        public IActionResult CreateProduct( )
        {
            return View();
        }

        [HttpPost]   //post metodu

        public IActionResult CreateProduct(Product entity)
        {
            return View();
        }
    }
}
