using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace YdyoOBS.Domain.Entities
{
    public class Derslik
    {
        public int Id { get; set; }

     
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int? SinifTurId { get; set; }
        public virtual SinifTur SinifTur { get; set; }
    }
}
