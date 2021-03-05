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

namespace YdyoOBS.Application.Siniflar.Queries.GetSiniflarList
{
    public class GetSiniflarListQuery : IRequest<List<SinifDto>>
    {
        public int DonemId { get; set; }

        public class GetSiniflarListQueryHandler : IRequestHandler<GetSiniflarListQuery, List<SinifDto>>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;

            public GetSiniflarListQueryHandler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<SinifDto>> Handle(GetSiniflarListQuery request, CancellationToken cancellationToken)
            {
                var siniflar = await _context.Siniflar
                    .Include(s => s.Kur).ThenInclude(k => k.Donem)
                    .Include(s => s.Hoca)
                    .Where(s=>s.DonemId==request.DonemId)
                    .OrderBy(s => s.Id)
                     .ProjectTo<SinifDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                // return _mapper.Map<List<SinifDto>>(siniflar);
                return siniflar;

            }
        }
    }
}
