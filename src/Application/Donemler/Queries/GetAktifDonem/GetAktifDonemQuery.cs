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

namespace YdyoOBS.Application.Donemler.Queries.GetAktifDonem
{
    public class GetAktifDonemQuery : IRequest<int>
    {
        public class GetAktifDonemQueryHandler : IRequestHandler<GetAktifDonemQuery, int>
        {
            private readonly IYdyoDbContext _context;

            public GetAktifDonemQueryHandler(IYdyoDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(GetAktifDonemQuery request, CancellationToken cancellationToken)
            {
                var donem = await _context.Donemler.Where(d => d.Aktif == true).FirstOrDefaultAsync();                
                return donem.Id;
            }
        }
    }
}
