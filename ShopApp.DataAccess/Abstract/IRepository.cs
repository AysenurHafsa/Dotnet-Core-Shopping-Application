﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int id);
        //kullanıcı bir id bilgisi gönderdiği zaman product tablosundan bulup geriye deger döndüren  metot
        T GetOne(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
