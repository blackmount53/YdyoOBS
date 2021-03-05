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

namespace YdyoOBS.Application.Ogrenciler.Queries.GetOgrenci
{
    public class GetOgrenciByIdQuery : IRequest<OgrenciDto>
    {
        public int Id { get; set; }


        public class GetOgrenciByIdQueryHandler : IRequestHandler<GetOgrenciByIdQuery, OgrenciDto>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;
            public GetOgrenciByIdQueryHandler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<OgrenciDto> Handle(GetOgrenciByIdQuery request, CancellationToken cancellationToken)
            {
                var ogrenci = await _context.Ogrenciler
                        .Include(o => o.Sinif)
                        .Include(o => o.Kur)
                        .Include(o => o.Donem)
                        .Where(o => o.Id == request.Id)
                        .ProjectTo<OgrenciDto>(_mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync();

                if (ogrenci == null)
                {
                    throw new NotFoundException(nameof(OgrenciDto), request.Id);
                }

                return ogrenci;
            }
        }

    }
}
