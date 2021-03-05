using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace YdyoOBS.Domain.Entities
{
    public class OgrenciSeviyeTespit
    {
        public int Id { get; set; }
        public int OgrId { get; set; }
        public string OgrNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Cinsiyeti { get; set; }
        public int? KurId { get; set; }
        public int? KurId2 { get; set; }
        public int? Kur { get; set; }
        public int? SinifId { get; set; }
        public int? SinifId2 { get; set; }
        public int? Sinif { get; set; }
        public int? DonemId { get; set; }
        public int? Devamsizlik { get; set; }
        public int? DevamsizlikSiniri { get; set; }
        public decimal? Notu { get; set; }
        public decimal? Midterm1 { get; set; }
        public decimal? Midterm2 { get; set; }
        public decimal? Ortalama { get; set; }
        public decimal? EskiOrtalama { get; set; }
        public int? KalanDevamsizlikHakkı { get; set; }
        public int? Activ { get; set; }
    }
}
