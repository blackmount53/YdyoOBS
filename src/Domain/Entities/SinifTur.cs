using System;
using System.Collections.Generic;


namespace YdyoOBS.Domain.Entities
{
    public class SinifTur
    {
        public int Id { get; set; }
        public string Adi { get; set; }

        public virtual ICollection<Derslik> Derslikler { get; set; }
    }
}
