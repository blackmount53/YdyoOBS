using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YdyoOBS.Application.Common.Interfaces;
using YdyoOBS.Domain.Entities;

namespace YdyoOBS.Application.Kurlar.Commands.CreateKur
{
    public class CreateKurCommand :IRequest<int>
    {
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int HDersSaati { get; set; }
        public int Devamsizlik { get; set; }
        public int DgsDevamsizlik { get; set; }
        public int DonemId { get; set; }


        public class Handler : IRequestHandler<CreateKurCommand, int>
        {
            private readonly IYdyoDbContext _context;

            public Handler(IYdyoDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateKurCommand request, CancellationToken cancellationToken)
            {   

                var entity = new Kur
                {
                    Adi = request.Adi,
                    Aciklama = request.Aciklama,
                    Devamsizlik = Convert.ToByte(request.Devamsizlik),
                    DevamsizlikDgs = Convert.ToByte(request.DgsDevamsizlik),
                    HdersSaati = request.HDersSaati,
                    DonemId = request.DonemId
                };

                _context.Kurlar.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;

            }
        }

    }
}
