using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace YdyoOBS.Domain.Entities
{
    public class Bolum
    {        
        public int Id { get; set; }       
        public string BolumNo { get; set; }
        public string FakulteNo { get; set; }
        public string Adi { get; set; }
        public string Name { get; set; }
        public int? DurumId { get; set; }
        public virtual Fakulte Fakulte { get; set; }
        public virtual BolumDurum BolumDurum { get; set; }

    }
}
