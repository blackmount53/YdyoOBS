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

namespace YdyoOBS.Application.Kurlar.Commands.UpdateKur
{
    public class UpdateKurCommand : IRequest
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int HDersSaati { get; set; }
        public int Devamsizlik { get; set; }
        public int DgsDevamsizlik { get; set; }
        public int DonemId { get; set; }

        public class Handler : IRequestHandler<UpdateKurCommand>
        {
            private readonly IYdyoDbContext _context;

            public Handler(IYdyoDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateKurCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Kurlar.SingleOrDefaultAsync(k=>k.Id==request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Kur), request.Id);
                }

                entity.Adi = request.Adi;
                entity.Aciklama = request.Aciklama;
                entity.DonemId = request.DonemId;
                entity.HdersSaati = request.HDersSaati;
                entity.Devamsizlik = Convert.ToByte(request.Devamsizlik);
                entity.DevamsizlikDgs = Convert.ToByte(request.DgsDevamsizlik);
                

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

    }
}
