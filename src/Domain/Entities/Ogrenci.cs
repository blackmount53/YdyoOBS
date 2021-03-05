using System;
using System.Collections.Generic;

namespace YdyoOBS.Domain.Entities
{
    public class Ogrenci 
    {
        public int Id { get; set; }
        public string OgrNo { get; set; }
        public string TCKimlikNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Cinsiyeti { get; set; }
        public string EvTel { get; set; }
        public string CepTel { get; set; }
        public string Eposta { get; set; }
        public int? KurId { get; set; }
        public int? SinifId { get; set; }
        public int? DonemId { get; set; }
        public DateTime? KayitTarihi { get; set; }
        public DateTime? DegTarihi { get; set; }
        public int? DegId { get; set; }
        public int? GirId { get; set; }
        public bool? Aktif { get; set; }
        public byte? Turu { get; set; }

        //Computed Columns
        public string FakulteAdi { get; set; }
        public string BolumAdi { get; set; }
        public decimal? Ort { get; set; }
        public decimal? Ortalama { get; set; }
        public int? Devamsiz { get; set; }
        public int? ToplamDevamsizlik { get; set; }
        public bool? IsDelete { get; set; }



        public virtual Sinif Sinif { get; set; }
        public virtual Kur Kur { get; set; }
        public virtual Donem Donem { get; set; }
        public virtual ICollection<SinavSonuc> SinavSonuclari { get; set; }
        public virtual ICollection<Devamsizlik> Devamsizliklar { get; set; }
        public virtual ICollection<Sinif> Temsilciler { get; set; }
    }
}
