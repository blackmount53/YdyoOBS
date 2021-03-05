using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YdyoOBS.Application.Common.Exceptions;
using YdyoOBS.Application.Common.Interfaces;
using YdyoOBS.Domain.Entities;

namespace YdyoOBS.Application.Ogrenciler.Commands.UpdateOgrenciCommand
{
    public class UpdateOgrenciCommand : IRequest
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
        public int? SinifId { get; set; }
        public bool Aktif { get; set; }

        public class Handler : IRequestHandler<UpdateOgrenciCommand>
        {
            private readonly IYdyoDbContext _context;

            public Handler(IYdyoDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateOgrenciCommand request, CancellationToken cancellationToken)
            {
                var sinif = await _context.Siniflar.FirstOrDefaultAsync(s => s.Id == request.SinifId);

                var entity = await _context.Ogrenciler.FirstOrDefaultAsync(o => o.Id == request.Id);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Ogrenci), request.Id);
                }

                entity.OgrNo = request.OgrNo;
                entity.TCKimlikNo = request.TCKimlikNo;
                entity.Adi = request.Adi;
                entity.Soyadi = request.Soyadi;
                entity.Cinsiyeti = request.Cinsiyeti; 
                entity.EvTel = request.EvTel;
                entity.CepTel = request.CepTel;
                entity.Eposta = request.Eposta;
                entity.SinifId = sinif.Id;
                entity.KurId = sinif.KurId;
                entity.DonemId = sinif.DonemId;
                entity.DegTarihi = DateTime.Now;
                entity.Aktif = sinif.Aktif;

                _context.Ogrenciler.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
                
            }
        }
    }
}
