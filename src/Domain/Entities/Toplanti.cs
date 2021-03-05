using System;
using System.Collections.Generic;

namespace YdyoOBS.Domain.Entities
{
    public class Toplanti
    {
        public int Id { get; set; }
        public string ToplantiAdi { get; set; }
        public string ToplantiKonusu { get; set; }
        public string ToplantiYeri { get; set; }
        public DateTime? ToplantiTarihi { get; set; }
        public int? HocaId { get; set; }
        public DateTime? KayitTarihi { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Hoca Hoca { get; set; }
    }
}
