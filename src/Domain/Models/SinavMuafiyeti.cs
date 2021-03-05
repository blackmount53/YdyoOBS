using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace YdyoOBS.Domain.Entities
{
    public class SinavMuafiyeti
    {
        public int Id { get; set; }
        public int? OgrId { get; set; }
        public int? SinavTurId { get; set; }
        public int? KulId { get; set; }
        public int? DonemId { get; set; }
        public DateTime? KayitTarihi { get; set; }
        public DateTime? SilTarih { get; set; }
        public int? SilId { get; set; }
        public bool? Aktiv { get; set; }
    }
}
