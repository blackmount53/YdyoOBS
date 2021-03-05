using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YdyoOBS.Application.Donemler.Queries.GetAktifDonem;
using YdyoOBS.Application.Donemler.Queries.GetDonemlerList;
using YdyoOBS.Application.Ogrenciler.Commands.CreateOgrenci;
using YdyoOBS.Application.Ogrenciler.Commands.UpdateOgrenci;
using YdyoOBS.Application.Ogrenciler.Queries.GetOgrenci;
using YdyoOBS.Application.Ogrenciler.Queries.GetOgrencilerList;
using YdyoOBS.Application.Ogrenciler.Queries.GetOgrencilerPagedList;
using YdyoOBS.Application.Ogrenciler.Queries.GetOgrencilerWithPagination;
using YdyoOBS.Application.Siniflar.Queries.GetSiniflarList;
using YdyoOBS.WebUI.Models.ViewModels;

namespace YdyoOBS.WebUI.Controllers
{
    public class OgrencilerController : Controller
    {

        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OgrencilerController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<IActionResult> Index(int pageNo=1,  int pageSize=10, int donemId=0, string search=null)
        {
            var donemler = await _mediator.Send(new GetDonemlerListQuery());
            if (donemId == 0)
            {
                donemId = donemler.First(x => x.Aktif == true).Id;
            }
            ViewData["DonemId"] = new SelectList(donemler, "Id", "Adi", donemId);
            ViewData["Donem"] = donemId;
            ViewData["Search"] = search;

            var ogrenciler = await _mediator.Send(new GetOgrencilerWithPaginationQuery() { PageNumber= pageNo,PageSize= pageSize, DonemId = donemId,Search = search });
            return View(ogrenciler);
        }


        public async Task<IActionResult> Yeni()
        {
            var donemId = await _mediator.Send(new GetAktifDonemQuery());
            var siniflar = await _mediator.Send(new GetSiniflarListQuery() { DonemId = donemId });
            ViewData["SinifId"] = new SelectList(siniflar, "Id", "Adi");
            var vm = new OgrenciVM() { DonemId = donemId };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Yeni(OgrenciVM vm)
        {
            if (ModelState.IsValid)
            {              
                await _mediator.Send(new CreateOgrenciCommand() { Adi = vm.Adi, Soyadi = vm.Soyadi, TCKimlikNo = vm.TCKNo, OgrNo = vm.OgrNo, CepTel = vm.Mobil, EvTel = vm.Telefon, Eposta = vm.Eposta, Cinsiyeti = vm.Cinsiyeti.Trim(), SinifId = vm.SinifId });
                return RedirectToAction(nameof(Index), new { donemId = vm.DonemId });
            }


            var siniflar = await _mediator.Send(new GetSiniflarListQuery() { DonemId = vm.DonemId });
            ViewData["SinifId"] = new SelectList(siniflar, "Id", "Adi");
            return View(vm);
        }


        public async Task<IActionResult> Duzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrenci = await _mediator.Send(new GetOgrenciByIdQuery() { Id = id.Value });
            if (ogrenci == null)
            {
                return NotFound();
            }

            var siniflar = await _mediator.Send(new GetSiniflarListQuery() { DonemId = ogrenci.DonemId });
            ViewData["SinifId"] = new SelectList(siniflar, "Id", "Adi", ogrenci.SinifId);

            var vm = new OgrenciVM
            {
                Id = ogrenci.Id,
                OgrNo = ogrenci.OgrNo,
                TCKNo = ogrenci.TCKimlikNo,
                Adi = ogrenci.Adi,
                Soyadi = ogrenci.Soyadi,
                Cinsiyeti = ogrenci.Cinsiyeti.Trim(),
                Telefon = ogrenci.EvTel,
                Mobil = ogrenci.CepTel,
                Eposta = ogrenci.Eposta,
                SinifId = ogrenci.SinifId,
                SinifAdi = ogrenci.SinifAdi,
                DonemId = ogrenci.DonemId,
                Aktif = ogrenci.Aktif
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(OgrenciVM vm)
        {
            if (ModelState.IsValid)
            {
                var claimIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);                
                var UserId = Convert.ToInt32(claim?.Value);


                await _mediator.Send(new UpdateOgrenciCommand() { Id =  vm.Id, TCKNo = vm.TCKNo, OgrNo =vm.OgrNo, Adi = vm.Adi, Soyadi =vm.Soyadi, 
                        Cinsiyeti = vm.Cinsiyeti,CepTel = vm.Mobil, EvTel = vm.Telefon, Eposta = vm.Eposta, Aktif = vm.Aktif, SinifId = vm.SinifId, UserId = UserId  });

                return RedirectToAction(nameof(Index), new { donemId = vm.DonemId });

            }

            var siniflar = await _mediator.Send(new GetSiniflarListQuery() { DonemId = vm.DonemId });
            ViewData["SinifId"] = new SelectList(siniflar, "Id", "Adi", vm.SinifId);
            return View(vm);
        }


        public async Task<IActionResult> Index2(int pageNo = 1, int pageSize = 10, int donemId = 0, string search = null)
        {
            var ogrenciler = await _mediator.Send(new GetOgrencilerPagedListQuery { PageNumber = pageNo, PageSize = pageSize, DonemId = donemId, Search = search });

            var donemler = await _mediator.Send(new GetDonemlerListQuery());

            if (donemId == 0)
            {
                donemId = donemler.First(x => x.Aktif == true).Id;
            }

            ViewData["DonemId"] = new SelectList(donemler, "Id", "Adi", donemId);
            ViewData["Donem"] = donemId;
            ViewData["Search"] = search;

            return View(ogrenciler);
        }

        public IActionResult IndexAjax()
        {
            return View();
        }

        public async Task<IActionResult> GetOgrenciler()
        {
            var ogrenciler =await _mediator.Send(new GetOgrencilerListQuery());
            return Ok(ogrenciler);
        }

    }
}
