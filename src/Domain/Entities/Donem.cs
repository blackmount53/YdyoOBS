using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YdyoOBS.Domain.Entities
{
    public class Donem
    {
        public Donem()
        {
            Aktif = Aktif ?? false;
        }
        
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool? Aktif { get; set; }

        public virtual ICollection<Kur> Kurlar { get; set; }
        public virtual ICollection<Sinif> Siniflar { get; set; }
        public virtual ICollection<SinavTur> SinavTurleri { get; set; }
        public virtual ICollection<Telafi> Telafiler { get; set; }
        public virtual ICollection<PacingList> PacingListler { get; set; }

        
    }
}
