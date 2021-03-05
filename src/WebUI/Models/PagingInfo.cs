using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YdyoOBS.WebUI.Models
{
    public class PagingInfo
    {
        // Toplam kayıt sayısı
        public int TotalItems { get; set; }

        //her sayfadaki gösterilecek kayıt
        public int ItemsPerPage { get; set; }

        // Güncel sayfa
        public int CurrentPage { get; set; }

        // Toplam Sayfa Sayısı
        public int TotalPage => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);

        // URL Adresim
        public string UrlParam { get; set; }
    }
}
