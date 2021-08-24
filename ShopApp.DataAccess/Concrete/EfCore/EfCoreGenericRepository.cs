using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class EfCoreGenericRepository<T, TContext> : IRepository<T>
        where T : class // T bir class olucak
        where TContext : DbContext, new()  // TContext ise DbContext ten türüyen bir yapı olucak
    {
        public void Create(T entity)
        {
            //biz ekledik
            using (var context = new TContext())
            {
                
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
