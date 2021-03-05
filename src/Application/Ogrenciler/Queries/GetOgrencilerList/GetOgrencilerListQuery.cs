using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YdyoOBS.Application.Common.Interfaces;
using YdyoOBS.Domain.Entities;

namespace YdyoOBS.Application.Ogrenciler.Queries.GetOgrencilerList
{
    public class GetOgrencilerListQuery : IRequest<List<Ogrenci>>
    {
      
        public class GetOgrencilerListQueryHandler : IRequestHandler<GetOgrencilerListQuery, List<Ogrenci>>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;
            public GetOgrencilerListQueryHandler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<Ogrenci>> Handle(GetOgrencilerListQuery request, CancellationToken cancellationToken)
            {
                var ogrenciler= await _context.Ogrenciler
                        .Include(o => o.Sinif)                        
                        .Include(o => o.Kur)
                        .Include(o => o.Donem)                        
                        .ToListAsync();

               return ogrenciler;
            }
        }
    }
}
