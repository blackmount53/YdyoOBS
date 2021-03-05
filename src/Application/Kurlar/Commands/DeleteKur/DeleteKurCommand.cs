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

namespace YdyoOBS.Application.Kurlar.Commands.DeleteKur
{
    public class DeleteKurCommand : IRequest
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteKurCommand>
        {
            private readonly IYdyoDbContext _context;

            public Handler(IYdyoDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteKurCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Kurlar.FirstOrDefaultAsync(k=>k.Id == request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Kur), request.Id);
                }

                _context.Kurlar.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;

            }
        }
    }
}
