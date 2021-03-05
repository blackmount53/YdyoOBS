using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using YdyoOBS.Application.Common.Exceptions;
using YdyoOBS.Application.Common.Interfaces;
using YdyoOBS.Domain.Entities;

namespace YdyoOBS.Application.Donemler.Commands.UpdateDonem
{
    public class UpsertDonemCommand : IRequest<int>
    {
        public int? Id { get; set; }
        public string Adi { get; set; }
        public bool Aktif { get; set; }

        public class Handler : IRequestHandler<UpsertDonemCommand, int>
        {
            private readonly IYdyoDbContext _context;

            public Handler(IYdyoDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpsertDonemCommand request, CancellationToken cancellationToken)
            {
                Donem entity;

                if (request.Id.HasValue && request.Id.Value > 0)
                {
                    entity = await _context.Donemler.FindAsync(request.Id.Value);
                }
                else
                {
                    entity = new Donem();
                    _context.Donemler.Add(entity);
                }
              
                //if (entity == null)
                //{
                //    throw new NotFoundException(nameof(Donem), request.Id);
                //}

                entity.Adi = request.Adi;
                entity.Aktif = request.Aktif;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }

    }
}
