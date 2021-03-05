using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YdyoOBS.WebUI.Models.ViewModels
{
    public class KurVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Kur Adı")]
        public string Adi { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [Display(Name = "Haftalık Ders Saati")]
        public int HDersSaati { get; set; }

        [Display(Name = "Devamsızlık Saati")]
        public int Devamsizlik { get; set; }

        [Display(Name = "DGS Devamsızlık Saati")]
        public int DgsDevamsizlik { get; set; }

        [Required]
        [Display(Name ="Dönem Seçiniz")]
        public int DonemId { get; set; }
    }
}
