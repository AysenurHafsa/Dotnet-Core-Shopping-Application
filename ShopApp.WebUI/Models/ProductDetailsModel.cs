using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    public class ProductDetailsModel
    {
        //details sayfasına eklenecek bilgiler burada yer alır 

        public Product Product { get; set; }

        public List<Category> Categories { get; set; }
    }
}
