using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YdyoOBS.Application.Common.Interfaces;

namespace YdyoOBS.Application.Siniflar.Commands.DeleteSinif
{
    public class DeleteSinifCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public class Handler: IRequestHandler<DeleteSinifCommand, bool>
        {
            private readonly IYdyoDbContext _context;

            public Handler(IYdyoDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(DeleteSinifCommand request, CancellationToken cancellationToken)
            {
                var sinif = await _context.Siniflar.FirstOrDefaultAsync(s => s.Id == request.Id);
                if (sinif == null)
                {
                    return false;
                }

                sinif.Aktif = false;
                await _context.SaveChangesAsync(cancellationToken);

                return true;

            }
        }
    }
}
