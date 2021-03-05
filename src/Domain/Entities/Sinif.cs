using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace YdyoOBS.Domain.Entities
{
    public class Sinif
    {       
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }        
        public int? DonemId { get; set; }
        public int? KurId { get; set; }
        public int? HocaId { get; set; }
        public bool? Aktif { get; set; }
        public int? TemsilciId { get; set; }
        public int? Sinif2 { get; set; }
        public string SinifAdi { get; set; }
        public int? Tur { get; set; }

       
        public virtual Kur Kur { get; set; }
        public virtual Donem Donem { get; set; }
        public virtual Hoca Hoca { get; set; }

        //[ForeignKey("TemsilciId")]
        public virtual Ogrenci Temsilci { get; set; }
        public virtual ICollection<SinavTur> SinavTurleri { get; set; }
        
    }
}
