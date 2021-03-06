using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Abstract
{
    public interface IProductDal:IRepository<Product>
    {
        // IProductDal IRepository içerisindeki bütün metotlara sahip
        List<Product> GetProductsByCategory(string category, int page , int pageSize);

        
        Product GetProductDetails(int id);

        int GetCountByCategory(string category);
    }

}
