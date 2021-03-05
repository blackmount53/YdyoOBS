using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YdyoOBS.Application.Common.Dto
{
    public class SinifDto
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool Aktif { get; set; }
        public int KurId { get; set; }        
        public string KurAdi { get; set; }
        public int? DonemId { get; set; }
        public string DonemAdi { get; set; }
        public int? HocaId { get; set; }
        public string HocaAdi { get; set; }
       
    }
}
