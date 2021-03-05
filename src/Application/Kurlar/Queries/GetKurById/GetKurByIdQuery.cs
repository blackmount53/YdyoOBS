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
using YdyoOBS.Application.Common.Exceptions;
using YdyoOBS.Application.Common.Interfaces;
using YdyoOBS.Domain.Entities;

namespace YdyoOBS.Application.Kurlar.Queries.GetKurById
{
    public class GetKurByIdQuery  :IRequest<KurDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetKurByIdQuery, KurDto>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;
            public Handler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<KurDto> Handle(GetKurByIdQuery request, CancellationToken cancellationToken)
            {
                var kur = await _context.Kurlar
                    .ProjectTo<KurDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(k => k.Id == request.Id);

                if (kur == null)
                {
                    throw new NotFoundException(nameof(Kur), request.Id);
                }

                return kur;
                        
            }
        }

    }
}
