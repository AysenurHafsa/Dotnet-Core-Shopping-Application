﻿using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.EfCore
{           //ctrl. diyince aşağıdaki metotlerı otomatik getirdi 
    public class EfCoreProductDal : EfCoreGenericRepository<Product, ShopContext>, IProductDal
    {   //businuss katmanı bu metodu kullanıyor...


        public Product GetProductDetails(int id)
        {
            using (var context = new ShopContext())
            {   //burada  ProductCategory ve Category bilgileri sorgusu databaseye yükleniyor.
                return context.Products
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategory)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category)
        {
            throw new NotImplementedException();
        }


        //public List<Product> GetProductsByCategory(string category)
        //{
        //    using (var context = new ShopContext())
        //    {
        //        var products = context.Products.AsQueryable();

        //        if (!string.IsNullOrEmpty(category)) //categoryleri listeliyor
        //        {
        //            products = products
        //                        .Include(i => i.ProductCategory)
        //                        .ThenInclude(i => i.Category)
        //                        .Where(i => i.ProductCategory.Any(a => a.Category.Name.ToLower() == category.ToLower()));
        //        }
        //        return products.ToList();
        //    }
        //}
    }
}