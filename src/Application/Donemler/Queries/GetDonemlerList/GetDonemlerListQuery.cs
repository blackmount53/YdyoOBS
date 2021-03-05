using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YdyoOBS.Application.Common.Dto;
using YdyoOBS.Application.Common.Interfaces;

namespace YdyoOBS.Application.Donemler.Queries.GetDonemlerList
{
    public class GetDonemlerListQuery : IRequest<List<DonemDto>>
    {
        public class GetDonemlerListQueryHandler : IRequestHandler<GetDonemlerListQuery, List<DonemDto>>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;
            public GetDonemlerListQueryHandler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<DonemDto>> Handle(GetDonemlerListQuery request, CancellationToken cancellationToken)
            {
                var donemler = await _context.Donemler.AsNoTracking().ToListAsync();

                return _mapper.Map<List<DonemDto>>(donemler);

            }
        }
    }
}
