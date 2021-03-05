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
using YdyoOBS.Domain.Entities;

namespace YdyoOBS.Application.Donemler.Queries.GetDonemById
{
    public class GetDonemByIdQuery : IRequest<DonemDto>
    {
        public int Id { get; set; }

        public class Handler: IRequestHandler<GetDonemByIdQuery, DonemDto>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DonemDto> Handle(GetDonemByIdQuery request, CancellationToken cancellationToken)
            {
                return  await _context.Donemler
                    .ProjectTo<DonemDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(d => d.Id == request.Id);
                
            }
        }
    }
}
