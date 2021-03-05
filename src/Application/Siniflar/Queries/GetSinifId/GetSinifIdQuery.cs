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

namespace YdyoOBS.Application.Siniflar.Queries.GetSinifId
{
    public class GetSinifIdQuery : IRequest<SinifDto>
    {
        public int Id { get; set; }

        public class GetSinifIdQueryHandler : IRequestHandler<GetSinifIdQuery, SinifDto>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;

            public GetSinifIdQueryHandler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SinifDto> Handle(GetSinifIdQuery request, CancellationToken cancellationToken)
            {
                return await _context.Siniflar.Where(s => s.Id == request.Id)
                    .Include(s => s.Kur)
                        .ThenInclude(k => k.Donem)
                    .Include(s => s.Hoca)
                    .ProjectTo<SinifDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();
                    
            }
        }

    }
}
