using System;
using System.Collections.Generic;

namespace YdyoOBS.Domain.Entities
{
    public class BolumDurum
    {
        public int Id { get; set; }
        public string Adi { get; set; }

        public virtual ICollection<Bolum> Bolumler { get; set; }
    }
}
