using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YdyoOBS.Application.Common.Dto;
using YdyoOBS.Application.Common.Models;
using YdyoOBS.Application.Donemler.Queries.GetDonemlerList;
using YdyoOBS.Application.Hocalar.Queries.GetHocalarList;
using YdyoOBS.Application.Kurlar.Queries.GetKurlarList;
using YdyoOBS.Application.Kurlar.Queries.GetKurListByDonemId;
using YdyoOBS.Application.Siniflar.Queries.GetSinifId;
using YdyoOBS.Application.Siniflar.Queries.GetSiniflarList;
using YdyoOBS.Application.Siniflar.Queries.GetSiniflarPagedList;
using YdyoOBS.Application.Siniflar.Queries.GetSiniflarWithPagination;

namespace YdyoOBS.WebUI.Controllers
{
    public class SiniflarController : Controller
    {
        private readonly IMediator _mediator;

        public SiniflarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _mediator.Send(new GetSiniflarListQuery()));
        //}

        public async Task<IActionResult> Index(int pageNo=1, int pageSize=10, int donemId = 0)
        {
            var donemler = await _mediator.Send(new GetDonemlerListQuery());
            if (donemId == 0)
            {
                donemId = donemler.First(x => x.Aktif == true).Id;
            }
            ViewData["DonemId"] = new SelectList(donemler, "Id", "Adi", donemId);
            ViewData["Donem"] = donemId;

            var siniflar = await _mediator.Send(new GetSiniflarWithPaginationQuery() { PageNumber = pageNo, PageSize = pageSize, DonemId = donemId });
            return View(siniflar);
        }


        public async Task<IActionResult> Duzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var model = await _mediator.Send(new GetSinifIdQuery { Id = id.Value });
            if (model == null)
            {
                return NotFound();
            }

            ViewData["KurId"] = new SelectList(await _mediator.Send(new GetKurListByDonemIdQuery { Id = model.DonemId.Value }),"Id","Adi");
            ViewData["HocaId"] = new SelectList(await _mediator.Send(new GetHocalarListQuery()), "Id", "TamAdi", model.HocaId);

            return View(model);

        }


        public  IActionResult Index2(int pageNo=1, int pageSize=10)
        {
            ViewBag.PageNo = pageNo;
            ViewBag.PageSize = pageSize;

            return View();
        }

        //[HttpGet("GetSiniflar")]
        
        public async Task<IActionResult> GetSiniflar(int pageNo = 1, int pageSize = 10)
        {
            var result= await _mediator.Send(new GetSiniflarPagedListQuery() { PageNo = pageNo, PageSize = pageSize });
            return Ok(  result );
        }

    }
}
