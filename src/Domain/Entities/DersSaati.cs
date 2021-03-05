using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YdyoOBS.Domain.Entities
{
    public class DersSaati
    {
        [Key]
        public int Id { get; set; }
        public string Saat { get; set; }
        public string Aciklama { get; set; }
    }
}
