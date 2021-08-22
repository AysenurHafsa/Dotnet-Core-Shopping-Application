using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class ProductCategory
    {
        // bu class'ı Product tablosu ile Category tablosunun birleşimi olan tablo gibi düşünebiliriz
        // iki entity'den gelen  Id lerini buraya ekledik ve
        //consion tabloda deniyor , bunu sor?
         public int CategoryId { get; set; }

         public Category Category { get; set; }
        // ve + her bir id'ye gelen navigation property leri buraya ekliyoruz,
         public int ProductId { get; set; }

         public Product Product { get; set; }
    }
}
