using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YdyoOBS.Application.Common.Dto;
using YdyoOBS.Application.Donemler.Queries.GetDonemlerList;
using YdyoOBS.Application.Ogrenciler.Queries.GetSinifOgrenciList;
using YdyoOBS.Application.Siniflar.Queries.GetSiniflarList;
using static YdyoOBS.Application.Ogrenciler.Queries.GetSinifOgrenciList.GetSinifOgrenciListQuery;

namespace YdyoOBS.WebUI.Controllers
{
    public class ListelerController : Controller
    {
        private readonly IMediator _mediator;

        public ListelerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> SinifListeleri(int donemId = 0, int sinifId = 0)
        {
            List<SinifOgrenciDto> SinifListesi = new List<SinifOgrenciDto>();

            var donemler = await _mediator.Send(new GetDonemlerListQuery());
            if (donemId == 0)
            {
                donemId = donemler.First(x => x.Aktif == true).Id;
            }

            var siniflar = await _mediator.Send(new GetSiniflarListQuery() { DonemId = donemId });          

            ViewData["DonemId"] = new SelectList(donemler, "Id", "Adi", donemId);
            ViewData["SinifId"] = new SelectList(siniflar, "Id", "Adi",sinifId);

            if (sinifId > 0)
            {             
                SinifListesi = await _mediator.Send(new GetSinifOgrenciListQuery() { SinifID = sinifId });
            }

            if (SinifListesi.Count() > 0)
            {
                ViewBag.HocaAdi = SinifListesi.FirstOrDefault().HocaAdi;
                ViewBag.SinifAdi = SinifListesi.FirstOrDefault().SinifAdi;
                ViewBag.KurAdı = SinifListesi.FirstOrDefault().KurAdi;
            }

            return View(SinifListesi);

        }
    }
}
