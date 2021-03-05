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

namespace YdyoOBS.Application.Ogrenciler.Queries.GetOgrencilerWithPagination
{
    public class GetOgrencilerWithPaginationQuery : IRequest<PaginatedList<OgrenciDto>>
    {
        public int DonemId { get; set; }
        public string Search { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public class Handler : IRequestHandler<GetOgrencilerWithPaginationQuery, PaginatedList<OgrenciDto>>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PaginatedList<OgrenciDto>> Handle(GetOgrencilerWithPaginationQuery request, CancellationToken cancellationToken)
            {

                if (request.DonemId == 0)
                {
                    //Aktif Dönem istelenecek
                    var donem = await _context.Donemler.Where(d => d.Aktif == true).FirstOrDefaultAsync();
                    request.DonemId = donem.Id;
                }

                var ogrenciler = _context.Ogrenciler
                        .Include(o => o.Sinif)
                        .Include(o => o.Kur)
                        .Include(o => o.Donem)
                        .Where(o => o.DonemId == request.DonemId)
                        .OrderBy(o => o.Id)
                        .AsQueryable();

                if (!string.IsNullOrEmpty(request.Search))
                {
                    ogrenciler = ogrenciler
                        .Where(o =>
                            o.OgrNo.Contains(request.Search) ||
                            o.TCKimlikNo.Contains(request.Search) ||
                            o.Adi.Contains(request.Search) ||
                            o.Soyadi.Contains(request.Search) ||
                            o.FakulteAdi.Contains(request.Search) ||
                            o.BolumAdi.Contains(request.Search)
                        );
                }

                return await ogrenciler
                    .ProjectTo<OgrenciDto>(_mapper.ConfigurationProvider)
                    .PaginatedListAsync(request.PageNumber, request.PageSize);

                //return await _context.Ogrenciler
                //    .Where(o => o.DonemId == request.DonemId)
                //    .Include(o => o.Sinif)
                //    .Include(o => o.Kur)
                //    .Include(o => o.Donem)
                //    .OrderBy(o => o.Id)
                //    .ProjectTo<OgrenciDto>(_mapper.ConfigurationProvider)
                //    .PaginatedListAsync(request.PageNumber, request.PageSize);
            }
        }

    }
}
