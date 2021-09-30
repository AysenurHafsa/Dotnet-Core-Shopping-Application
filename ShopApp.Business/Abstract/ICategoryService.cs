﻿using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface ICategoryService
    {
         Category GetById(int id); // editcategory icin grekli metodu ekledik

        Category GetByIdWithProducts(int id);

        List<Category> GetAll();

        void Create(Category entity);

        void Update(Category entity);

        void Delete(Category entity);
        void DeleteFromCategory(int categoryId, int productId);
    }
}
