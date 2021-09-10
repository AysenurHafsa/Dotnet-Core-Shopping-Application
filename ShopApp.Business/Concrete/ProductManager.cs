﻿using ShopApp.Business.Abstract;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Business.Concrete
{
    public class ProductManager : IProductService
    {
        //  EfCoreProductDal _productDal = new EfCoreProductDal();   //bunu silip bağımlılığımı kaldırmak için 
        // alttaki satırları ekledik(1,2,3)
        private IProductDal _productDal;  //1

        public ProductManager(IProductDal productDal)  //2
        {
            _productDal = productDal;   //3
        }

        public void Create(Product entity)
        {
            _productDal.Create(entity); //entity gönderince kayıt bilgisi oluşuyor
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);   // entity gönderince kayıt bilgisi siliniyor
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();//kayıt istiyorsak GetAll alır toliste gönderir
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id); //tek bir kaydı istiyorsak GetById çağırıp id gönderdik 
        }

        public List<Product> GetPopularProducts()
        {
            return _productDal.GetAll();
        }

        public Product GetProductDetails(int id)
        {
            return _productDal.GetProductDetails(id);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity); // update işlemleri 
        }
    }
}
