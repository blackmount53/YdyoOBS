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

namespace YdyoOBS.Application.Hocalar.Queries.GetHocalarList
{
    public class GetHocalarListQuery : IRequest<List<HocaDto>>
    {
        public class GetHocalarListQueryHandler : IRequestHandler<GetHocalarListQuery, List<HocaDto>>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;

            public GetHocalarListQueryHandler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<HocaDto>> Handle(GetHocalarListQuery request, CancellationToken cancellationToken)
            {
                return await _context
                    .Hocalar
                    .AsNoTracking()
                    .ProjectTo<HocaDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            }
        }
    }
}
