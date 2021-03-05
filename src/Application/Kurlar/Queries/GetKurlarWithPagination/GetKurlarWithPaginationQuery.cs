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
using YdyoOBS.Application.Common.Mappings;
using YdyoOBS.Application.Common.Models;

namespace YdyoOBS.Application.Kurlar.Queries.GetKurlarWithPagination
{
    public class GetKurlarWithPaginationQuery : IRequest<PaginatedList<KurDto>>
    {
        public int DonemId { get; set; }     
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public class GetKurlarWithPaginationQueryHandler : IRequestHandler<GetKurlarWithPaginationQuery, PaginatedList<KurDto>>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;

            public GetKurlarWithPaginationQueryHandler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PaginatedList<KurDto>> Handle(GetKurlarWithPaginationQuery request, CancellationToken cancellationToken)
            {
                if (request.DonemId == 0)
                {
                    //Aktif Dönem istelenecek
                    var donem = await _context.Donemler.Where(d => d.Aktif == true).FirstOrDefaultAsync();
                    request.DonemId = donem.Id;
                }

                var kurlar = _context.Kurlar
                    .Include(k => k.Donem)
                    .Where(k => k.DonemId == request.DonemId)
                    .OrderBy(k => k.Id);

                return await kurlar
                    .ProjectTo<KurDto>(_mapper.ConfigurationProvider)
                    .PaginatedListAsync(request.PageNumber, request.PageSize);

            }
        }

    }
}
