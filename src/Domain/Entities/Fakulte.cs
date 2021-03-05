using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace YdyoOBS.Domain.Entities
{
    public class Fakulte
    {      
        public string FakulteNo { get; set; }
        public string Adi { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Bolum> Bolumler { get; set; }
    }
}
