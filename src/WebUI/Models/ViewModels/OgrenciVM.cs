using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YdyoOBS.WebUI.Models.ViewModels
{
    public class OgrenciVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Öğrenci nosunu giriniz.")]
        [Display(Name ="Öğrenci No")]
        public string OgrNo { get; set; }

        [Display(Name = "T.C Kimlik No")]
        public string TCKNo { get; set; }
        
        [Required(ErrorMessage ="Öğrenci adını giriniz.")]
        [Display(Name = "Öğrenci Adı")]
        public string Adi { get; set; }

        [Required(ErrorMessage ="Öğrenci soyadını giriniz.")]
        [Display(Name = "Öğrenci Soyadı")]
        public string Soyadi { get; set; }        
        public string Cinsiyeti { get; set; }
        public string Telefon { get; set; }
        public string Mobil { get; set; }

        [Display(Name = "E-Posta")]
        [EmailAddress(ErrorMessage ="Geçersiz e-posta adresi.")]
        public string Eposta { get; set; }

        [Required(ErrorMessage ="Sınıf seçiniz.")]
        [Display(Name = "Sınıf")]
        public int SinifId { get; set; }

        [Display(Name ="Sınıf Adı")]
        public string SinifAdi { get; set; }
        public bool Aktif { get; set; }
        public int DonemId { get; set; }
        public int? KulId { get; set; }

    }
}
