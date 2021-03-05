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
using YdyoOBS.Application.Common.Models;
using YdyoOBS.Domain.Entities;

namespace YdyoOBS.Application.Ogrenciler.Queries.GetOgrencilerPagedList
{
    public class GetOgrencilerPagedListQuery : IRequest<PagedList<OgrenciDto>>
    {
        public int DonemId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
        public class Handler : IRequestHandler<GetOgrencilerPagedListQuery, PagedList<OgrenciDto>>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PagedList<OgrenciDto>> Handle(GetOgrencilerPagedListQuery request, CancellationToken cancellationToken)
            {
                
                if (request.DonemId == 0)
                {
                    var donem = await _context.Donemler.FirstOrDefaultAsync(d => d.Aktif == true);
                    request.DonemId =donem.Id;
                
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

                var liste = PagedList<OgrenciDto>.ToPagedList(ogrenciler.ProjectTo<OgrenciDto>(_mapper.ConfigurationProvider), request.PageNumber, request.PageSize);

                return liste;
            }
        }
    }
}
