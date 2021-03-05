using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace YdyoOBS.Domain.Entities
{
    public class AnketCevap
    {
        public int CevapId { get; set; }
        public int? AnketId { get; set; }
        public string Cevap { get; set; }
        public int? Hit { get; set; }
    }
}
