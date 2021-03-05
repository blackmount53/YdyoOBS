using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace YdyoOBS.Domain.Entities
{
    public class Kur
    {
        public int Id { get; set; }        
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public byte? Devamsizlik { get; set; }
        public byte? DevamsizlikDgs { get; set; }
        public int? HdersSaati { get; set; }
        public int? DonemId { get; set; }


        [ForeignKey("DonemId")]
        public virtual Donem Donem { get; set; }

        public virtual ICollection<Sinif> Siniflar { get; set; }


    }
}
