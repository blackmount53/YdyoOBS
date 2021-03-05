using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace YdyoOBS.Domain.Entities
{
    public class Iletisim
    {
        public int IletisimId { get; set; }
        public int? SinifId { get; set; }
        public int? OgrId { get; set; }
        public string Tel { get; set; }
    }
}
