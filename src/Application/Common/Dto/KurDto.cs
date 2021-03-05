using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YdyoOBS.Application.Common.Dto
{
    public class KurDto
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int DonemId { get; set; }
        public int HDersSaati { get; set; }
        public int DevamsizlikSaati { get; set; }
        public int DGSDevamsizlikSaati { get; set; }
        public string DonemAdi { get; set; }

    }
}
