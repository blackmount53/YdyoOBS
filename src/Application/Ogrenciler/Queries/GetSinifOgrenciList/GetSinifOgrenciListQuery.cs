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

namespace YdyoOBS.Application.Ogrenciler.Queries.GetSinifOgrenciList
{
    public class GetSinifOgrenciListQuery : IRequest<List<SinifOgrenciDto>>
    {
        public int SinifID { get; set; }

        public class GetSinifOgrenciListQueryHandler : IRequestHandler<GetSinifOgrenciListQuery, List<SinifOgrenciDto>>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;

            public GetSinifOgrenciListQueryHandler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<SinifOgrenciDto>> Handle(GetSinifOgrenciListQuery request, CancellationToken cancellationToken)
            {
                return await _context.Ogrenciler
                                    .Include(o => o.Sinif)
                                        .ThenInclude(s => s.Kur)
                                    .Include(o=>o.Sinif)    
                                        .ThenInclude(h=>h.Hoca)
                                    .Where(o => o.SinifId == request.SinifID && o.Aktif == true)
                                    .OrderBy(o => o.Adi).ThenBy(o => o.Soyadi)
                                    .ProjectTo<SinifOgrenciDto>(_mapper.ConfigurationProvider)
                                    .ToListAsync();
               
            }
        }
    }
    
}
