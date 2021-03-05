using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace YdyoOBS.Domain.Entities
{
    public class AnketSoru
    {
        public int AnketId { get; set; }
        public string Soru { get; set; }
        public bool? Onay { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public int? KulId { get; set; }
        public DateTime? OlusturmaTarihi { get; set; }
        public string SoruTipi { get; set; }
    }
}
