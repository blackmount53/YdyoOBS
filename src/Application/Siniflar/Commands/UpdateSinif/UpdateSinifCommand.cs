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

namespace YdyoOBS.Application.Siniflar.Commands.UpdateSinif
{
    public class UpdateSinifCommand : IRequest
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int KurId { get; set; }
        public int? HocaId { get; set; }
        public bool Aktif { get; set; }

        public class Handler : IRequestHandler<UpdateSinifCommand>
        {
            private readonly IYdyoDbContext _context;

            public Handler(IYdyoDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateSinifCommand request, CancellationToken cancellationToken)
            {
                var kur = await _context.Kurlar.FirstOrDefaultAsync(k => k.Id == request.KurId);

                var entity = await _context.Siniflar.FirstOrDefaultAsync(s => s.Id == request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Sinif), request.Id);
                }


                entity.Adi = request.Adi;
                entity.Aciklama = request.Aciklama;
                entity.Aktif = request.Aktif;
                entity.KurId = request.KurId;
                entity.DonemId = kur.DonemId;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;

            }
        }

    }
}
