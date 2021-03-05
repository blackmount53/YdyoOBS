using System;
using System.Collections.Generic;

namespace YdyoOBS.Domain.Entities
{
    public class Hoca
    {
        public int Id { get; set; }
        public string Kisaltma { get; set; }
        public string AdSoyad { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KulAdi { get; set; }
        public string Parola { get; set; }
        public string Email { get; set; }
        public bool? Aktiv { get; set; }
        public DateTime? KayitTarih { get; set; }
        public DateTime? SonGirisTarih { get; set; }
        public DateTime? ParolaDegisTarih { get; set; }
        public bool? Yetki { get; set; }
        public bool? Danisman { get; set; }
        public string EskiKulAdi { get; set; }
        public string EskiParola { get; set; }
        public int? Sayi { get; set; }
        public string Sifre { get; set; }
        public int? Rol { get; set; }
        public bool? Onay { get; set; }
        public string Resim { get; set; }
        public virtual ICollection<Sinif> Siniflar { get; set; }
        public virtual ICollection<SinavSonuc> SinavSonuclari { get; set; }
        public virtual ICollection<Devamsizlik> Devamsizliklar { get; set; }
        public virtual ICollection<Telafi> Telafiler { get; set; }
        public virtual ICollection<PacingList> PacingListler { get; set; }
        public virtual ICollection<Toplanti> Toplantilar { get; set; }

    }
}
