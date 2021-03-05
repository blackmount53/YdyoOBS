using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using YdyoOBS.Application.Common.Dto;
using YdyoOBS.Application.Common.Interfaces;
using YdyoOBS.Application.Common.Mappings;
using YdyoOBS.Application.Common.Models;

namespace YdyoOBS.Application.Siniflar.Queries.GetSiniflarWithPagination
{
    public class GetSiniflarWithPaginationQuery : IRequest<PaginatedList<SinifDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int DonemId { get; set; }


        public class GetSiniflarWithPaginationQueryHandler : IRequestHandler<GetSiniflarWithPaginationQuery, PaginatedList<SinifDto>>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;

            public GetSiniflarWithPaginationQueryHandler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PaginatedList<SinifDto>> Handle(GetSiniflarWithPaginationQuery request, CancellationToken cancellationToken)
            {
                if (request.DonemId == 0)
                {
                    var donem = await _context.Donemler.Where(d => d.Aktif == true).FirstOrDefaultAsync();
                    request.DonemId = donem.Id;
                }

                var siniflar = _context.Siniflar
                    .Include(s => s.Kur)
                        .ThenInclude(k => k.Donem)
                    .Where(s=>s.DonemId==request.DonemId)
                    .OrderBy(s => s.Id);

                return await siniflar
                    .ProjectTo<SinifDto>(_mapper.ConfigurationProvider)
                    .PaginatedListAsync(request.PageNumber, request.PageSize);

            }
        }

    }
}
