using System;
using System.Collections.Generic;


namespace YdyoOBS.Domain.Entities
{
    public partial class SinavSonuc
    {
        public int Id { get; set; }
        public int? OgrId { get; set; }
        public int? SinavTurId { get; set; }
        public int? HocaId { get; set; }
        public DateTime? KayitTarihi { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
        public int? DonemId { get; set; }
        public decimal? Notu { get; set; }

        public virtual Hoca Hoca { get; set; }
        public virtual Ogrenci Ogrenci { get; set; }
        public virtual SinavTur SinavTur { get; set; }
        public virtual Donem Donem { get; set; }

    }
}
