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
        public IActionResult AddProduct()
        {
            ViewBag.AllCategories = _categoryService.GetAll();

            var emptyModel = new ProductModel();
            return View(emptyModel);
        }

        [HttpPost]   //post metodu
        public IActionResult AddProduct(ProductModel model)  //sayfadan model aldıyoruz
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

            return RedirectToAction("ProductList"); //kullanıcıyı yeni bir sayfaya yonlendiriyoruz //raute yonlendirme yaptık (ToAction)
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

            return RedirectToAction("ProductList");  //raute yonlendirme yaptık (ToAction)
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId) //silme islemi yapan metot
        {
            var entity = _productService.GetById(productId);

            if (entity != null)
            {
                _productService.Delete(entity);
            }

            return RedirectToAction("ProductList");
        }
        public IActionResult CategoryList()
        {
            return View(new CategoryListModel()
            {
                Categories = _categoryService.GetAll()  //category servisinden gelen kategorileri categories e atarız
            });
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryModel model)
        {
            var entity = new Category()
            {
                Name = model.Name //modelden gelen name alıyor
            };
            _categoryService.Create(entity);  //category service uzerinden create ile entity i gönderiyoruz

            return RedirectToAction("CategoryList"); //kullanıcıyı categorylist actiona gidip ekledigi urunu gorur
        }
        //edit sayfalarını ekliyoruz

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var entity = _categoryService.GetByIdWithProducts(id); //gonderdigimiz category deki bilgiyi alıyoruz

            return View(new CategoryModel() //kullanıcıya categoryi model olarak gönderiyoruz 
            {
                Id = entity.Id,   // id ve name i entityden gelen bilgiyle dolduruyoruz model olarak sayfaya gönderiyoruz
                Name = entity.Name,
                Products =entity.ProductCategories.Select(p=>p.Product).ToList()
            });
        }
        [HttpPost]
        public IActionResult EditCategory(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.Id); //sayfadan gelen model bilgisiyle databasedeki ilgili modeli aldık
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = model.Name;
            _categoryService.Update(entity); //Updateye sectigimiz ve yeni bilgilerle doldurdugumuz yeni entityi gönderiyoruz

            return RedirectToAction("CategoryList"); ; //islemi categoryliste gonderiyoruz
        }
        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)  //categorylist sayfasındaki delete butonu icin gerekli metot umuz.
        {
            var entity = _categoryService.GetById(categoryId);

            if (entity != null)
            {
                _categoryService.Delete(entity);
            }


            return RedirectToAction("CategoryList");
        }
    }
}
