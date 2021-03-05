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

namespace YdyoOBS.Application.Siniflar.Queries.GetSiniflarPagedList
{
    public class GetSiniflarPagedListQuery : IRequest<PagedList<SinifDto>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }

        public class GetSiniflarPagedListQueryHandler : IRequestHandler<GetSiniflarPagedListQuery, PagedList<SinifDto>>
        {
            private readonly IYdyoDbContext _context;
            private readonly IMapper _mapper;

            public GetSiniflarPagedListQueryHandler(IYdyoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public  Task<PagedList<SinifDto>> Handle(GetSiniflarPagedListQuery request, CancellationToken cancellationToken)
            {
                var siniflar =  _context.Siniflar
                    .Include(s => s.Kur).ThenInclude(k => k.Donem)
                    .Include(s => s.Hoca)
                    .ProjectTo<SinifDto>(_mapper.ConfigurationProvider)
                    .OrderBy(s => s.Id)                    
                    .AsQueryable();

                var liste = PagedList<SinifDto>.ToPagedList(siniflar, request.PageNo, request.PageSize);

                return Task.FromResult(liste);


            }
        }
    }
}
