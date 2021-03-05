using System;
using System.Collections.Generic;

namespace YdyoOBS.Domain.Entities
{
    public class Devamsizlik
    {
        public int Id { get; set; }
        public int? DonemId { get; set; }
        public int? OgrId { get; set; }
        public int? HocaId { get; set; }
        public int? Ay { get; set; }
        public int? Saat { get; set; }
        public DateTime? KayitTarih { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }

        public virtual Donem Donem { get; set; }
        public virtual Ogrenci Ogrenci { get; set; }
        public virtual Hoca Hoca { get; set; }
    }
}
