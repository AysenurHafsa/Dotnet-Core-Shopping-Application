using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    public class PageInfo
    {
        public int TotalItems { get; set; } //toplam urun (eleman) sayisi saklar

        public int ItemsPerPage { get; set; } // her sayfada kac tane eleman gostermek istedigimiz bilgisini saklar

        public int CurrentPage { get; set; } // o anki hangi sayfadayız bilgisini saklar

        public string CurrentCategory { get; set; } // o andaki aktif olan kategori bilgisini tutar

        public int TotalPages() //PageInfo uzerinden gonderilen bilgilere gore kac tane sayfa uretmek istedigimizi bu metotdan alicaz
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }
    }
    public class ProductListModel
    {
        public PageInfo PageInfo { get; set; } //sayfa bilgisi

        public List<Product> Products { get; set; }

    }
}
