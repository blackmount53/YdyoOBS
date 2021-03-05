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

namespace YdyoOBS.Application.Siniflar.Commands.CreateSinif
{
    public class CreateSinifCommand : IRequest<int>
    {
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int KurId { get; set; }
        public int? HocaId { get; set; }

        public class Handler : IRequestHandler<CreateSinifCommand, int>
        {
            private readonly IYdyoDbContext _context;

            public Handler(IYdyoDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateSinifCommand request, CancellationToken cancellationToken)
            {
                var kur = await _context.Kurlar.FirstOrDefaultAsync(k => k.Id == request.KurId);

                var sinif = new Sinif
                {
                    Adi = request.Adi,
                    Aciklama = request.Aciklama,
                    KurId = request.KurId,
                    DonemId = kur.DonemId,
                    Aktif = true,
                    HocaId = request.HocaId
                };

                _context.Siniflar.Add(sinif);
                await _context.SaveChangesAsync(cancellationToken);
                return sinif.Id;

            }
        }

    }
}
