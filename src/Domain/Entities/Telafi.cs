using System;
using System.Collections.Generic;

namespace YdyoOBS.Domain.Entities
{
    public class Telafi
    {
        public int Id { get; set; }
        public int? SinifId { get; set; }
        public int? HocaId { get; set; }
        public int? DersId { get; set; }
        public int? DerslikId { get; set; }
        public string Tarih { get; set; }
        public string TelafiTarihi { get; set; }
        public string Aciklama { get; set; }
        public int? OnayId { get; set; }
        public bool? Onay { get; set; }
        public DateTime? OnayTarihi { get; set; }
        public int? DonemId { get; set; }
        public DateTime? GirTarih { get; set; }


        public virtual Sinif Sinif { get; set; }
        public virtual Hoca Hoca { get; set; }
        public virtual Ders Ders { get; set; }
        public virtual Derslik Derslik { get; set; }
        public virtual Donem Donem { get; set; }

        //public virtual  Hoca Onaylayan { get; set; }

    }
}
