using System;
using System.Collections.Generic;


namespace YdyoOBS.Domain.Entities
{
    public class SinavTur
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool? Aktif { get; set; }
        public string Aciklama { get; set; }
        public int? SinifId { get; set; }
        public int? DonemId { get; set; }       
        public decimal? Katsayi { get; set; }
        public int? Siralama { get; set; }
        public virtual Donem Donem { get; set; }
        public virtual Sinif Sinif { get; set; }

    }
}
