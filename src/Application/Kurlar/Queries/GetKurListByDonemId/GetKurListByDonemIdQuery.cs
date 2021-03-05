using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace YdyoOBS.Application.Kurlar.Queries.GetKurListByDonemId
{
    public class GetKurListByDonemIdQuery : IRequest<List<KurDto>>
    {
        public int Id { get; set; }

        public class GetKurListByDonemIdQueryHandler : IRequestHandler<GetKurListByDonemIdQuery, List<KurDto>>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;

            public GetKurListByDonemIdQueryHandler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<KurDto>> Handle(GetKurListByDonemIdQuery request, CancellationToken cancellationToken)
            {
                return await _context.Kurlar
                    .Where(k=>k.DonemId==request.Id)
                    .Include(k => k.Donem)
                    .AsNoTracking()
                    .OrderBy(k => k.Id)
                    .ProjectTo<KurDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }
    }
}
