using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    public class ShopController : Controller //injeck islemi( HomeControllerdan aldık)
    {
        private IProductService _productService;


        public ShopController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(new ProductListModel()  // productListModel donduruyor (HOmeController dan aldık)
            {
                Products = _productService.GetAll() //GetAll= tum urunler

            });
        }
    }
}
