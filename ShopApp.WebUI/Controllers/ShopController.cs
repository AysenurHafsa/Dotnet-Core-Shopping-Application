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
    public class ShopController : Controller //injeck islemi( HomeControllerdan aldık)
    {
        private IProductService _productService;


        public ShopController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Details(int? id) //urun detay bilgisine yonlendirir
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product=_productService.GetProductDetails((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailsModel() 
            { 
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()
                // category bilgilerini link ile categories'e aktarıyor.
            });
        }
        public IActionResult List(string category, int page=1)
        {
            const int pageSize = 3;
            return View(new ProductListModel()  // productListModel donduruyor (HOmeController dan aldık)
            {
                Products = _productService.GetProductsByCategory(category, page, pageSize) //kategorilere gore tum urunler listeleniyor

            });
        }
    }
}
