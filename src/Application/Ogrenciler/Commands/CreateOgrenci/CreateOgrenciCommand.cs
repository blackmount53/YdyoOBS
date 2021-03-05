using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YdyoOBS.Application.Common.Interfaces;
using YdyoOBS.Domain.Entities;

namespace YdyoOBS.Application.Ogrenciler.Commands.CreateOgrenci
{
    public class CreateOgrenciCommand : IRequest<int>
    {
        public string OgrNo { get; set; }
        public string TCKimlikNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Cinsiyeti { get; set; }
        public string EvTel { get; set; }
        public string CepTel { get; set; }
        public string Eposta { get; set; }
        public int? SinifId { get; set; }

        public class Handler : IRequestHandler<CreateOgrenciCommand, int>
        {
            private readonly IYdyoDbContext _context;

            public Handler(IYdyoDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateOgrenciCommand request, CancellationToken cancellationToken)
            {
                var sinif = await _context.Siniflar.FirstOrDefaultAsync(s => s.Id == request.SinifId);

                var entity = new Ogrenci
                {
                    OgrNo = request.OgrNo,
                    TCKimlikNo = request.TCKimlikNo,
                    Adi = request.Adi,
                    Soyadi = request.Soyadi,
                    Cinsiyeti = request.Cinsiyeti,
                    EvTel = request.EvTel,
                    CepTel = request.CepTel,
                    Eposta = request.Eposta,
                    SinifId = request.SinifId,
                    KurId = sinif?.KurId,
                    DonemId = sinif?.DonemId,
                    Aktif = true
                };

                _context.Ogrenciler.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }

    }
}
