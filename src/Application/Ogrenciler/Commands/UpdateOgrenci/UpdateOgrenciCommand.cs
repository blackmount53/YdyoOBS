using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YdyoOBS.Application.Common.Interfaces;

namespace YdyoOBS.Application.Ogrenciler.Commands.UpdateOgrenci
{
    public class UpdateOgrenciCommand: IRequest<bool>
    {
        public int Id { get; set; }
        public string TCKNo { get; set; }
        public string OgrNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Cinsiyeti { get; set; }
        public string EvTel { get; set; }
        public string CepTel { get; set; }
        public string Eposta { get; set; }
        public int SinifId { get; set; }
        public bool Aktif { get; set; }
        public int? UserId { get; set; }

        //public int DonemId { get; set; }

        public class Handler: IRequestHandler<UpdateOgrenciCommand, bool>
        {
            private readonly IYdyoDbContext _context;

            public Handler(IYdyoDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(UpdateOgrenciCommand request, CancellationToken cancellationToken)
            {
                var ogrenci = await _context.Ogrenciler.FirstOrDefaultAsync(o => o.Id == request.Id);
                if(ogrenci==null)
                {
                    return false;
                }

                var sinif = _context.Siniflar.FirstOrDefault(s => s.Id == request.SinifId);

                ogrenci.TCKimlikNo = request.TCKNo;
                ogrenci.OgrNo = request.OgrNo;
                ogrenci.Adi = request.Adi;
                ogrenci.Soyadi = request.Soyadi;
                ogrenci.Cinsiyeti = request.Cinsiyeti.Trim();
                ogrenci.EvTel = request.EvTel;
                ogrenci.CepTel = request.CepTel;
                ogrenci.Eposta = request.Eposta;
                ogrenci.SinifId = request.SinifId;
                ogrenci.DonemId = sinif.DonemId;
                ogrenci.KurId = sinif.KurId;
                ogrenci.Aktif = sinif.Aktif;
                ogrenci.DegId = request.UserId;
                ogrenci.DegTarihi = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);
                return true;

            }
        }

    }
}
