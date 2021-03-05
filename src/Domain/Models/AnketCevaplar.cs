using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace YdyoOBS.Domain.Entities
{
    public class AnketCevaplar
    {
        public int AnketCevaplarId { get; set; }
        public int? AnketId { get; set; }
        public int? CevapId { get; set; }
        public int? Hit { get; set; }
        public int? HocaId { get; set; }
        public DateTime? AnketCevapTarihi { get; set; }
    }
}
