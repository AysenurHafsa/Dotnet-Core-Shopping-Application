﻿using Microsoft.AspNetCore.Mvc;
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
        private ICategoryService _categoryService; //injeck islemi yaptık

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult ProductList()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll() //productlar listeleniyor
            });
        }

        [HttpGet]     //form u getiricek metot(parametresiz)

        public IActionResult CreateProduct()
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
                Description = model.Description,
                ImageUrl = model.ImageUrl
            };
            _productService.Create(entity); //kayıt islemi yapıyor

            return RedirectToAction("Index"); //kullanıcıyı yeni bir sayfaya yonlendiriyoruz //raute yonlendirme yaptık (ToAction)
        }

        public IActionResult EditProduct(int? id)  //edit sayfasina yonlendiren metodumuz
        {
            if (id == null)   //kullanıcı id gondermesse kullanıcıya sayfa bulunamadı yönlendirmesi yapıyor.
            {
                return NotFound();
            }
            var entity = _productService.GetById((int)id);

            if (entity == null)  //entity yoksa kullanıcıya sayfa bulunamadı yönlendirmesi yapıyor.
            {
                return NotFound();
            }

            var model = new ProductModel()
            {
                //burada bilgiyi model icinde paketliyoruz ve sayfaya gonderiyoruz.
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult EditProduct(ProductModel model)
        {
            var entity = _productService.GetById(model.Id);

            if (entity == null)
            {
                return NotFound();

            }
            //sayfadan gelen bilgilerle database den aldigimiz enttity nin alanlarını burada set ediyoruz
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            entity.Price = model.Price;

            _productService.Update(entity); //set islemi bittikten sonra Update yi cagirip entityi gonderiyoruz.

            return RedirectToAction("Index");  //raute yonlendirme yaptık (ToAction)
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId) //silme islemi yapan metot
        {
            var entity = _productService.GetById(productId);

            if (entity == null)
            {
                return NotFound();   
            }
            _productService.Delete(entity);

           TempData["DeleteMessage"] = "The product has been deleted successfully.";

            return RedirectToAction("Index");
        }
        public IActionResult CategoryList()
        {
            return View( new CategoryListModel()
            { 
              Categories =_categoryService.GetAll()  //category servisinden gelen kategorileri categories e atarız
            });
        }
    }
}
