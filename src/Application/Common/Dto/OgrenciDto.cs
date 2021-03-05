using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YdyoOBS.Application.Common.Dto
{
    public class OgrenciDto
    {
        public int Id { get; set; }
        public string OgrNo { get; set; }
        public string TCKimlikNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Cinsiyeti { get; set; }
        public string EvTel { get; set; }
        public string CepTel { get; set; }
        public string Eposta { get; set; }
        public int KurId { get; set; }
        public string KurAdi { get; set; }
        public int SinifId { get; set; }
        public string SinifAdi { get; set; }
        public int DonemId { get; set; }
        public string DonemAdi { get; set; }    
        public DateTime KayitTarihi { get; set; }        
        public bool Aktif { get; set; }
        public string FakulteAdi { get; set; }
        public string BolumAdi { get; set; }

    }
}
