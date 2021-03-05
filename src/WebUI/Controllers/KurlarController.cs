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
using YdyoOBS.Application.Kurlar.Commands.CreateKur;
using YdyoOBS.Application.Kurlar.Commands.DeleteKur;
using YdyoOBS.Application.Kurlar.Commands.UpdateKur;
using YdyoOBS.Application.Kurlar.Queries.GetKurById;
using YdyoOBS.Application.Kurlar.Queries.GetKurlarList;
using YdyoOBS.Application.Kurlar.Queries.GetKurlarWithPagination;
using YdyoOBS.WebUI.Models.ViewModels;

namespace YdyoOBS.WebUI.Controllers
{
    public class KurlarController : Controller
    {
        private readonly IMediator _mediator;

        public KurlarController(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<IActionResult> Index(int pageNo = 1, int pageSize = 10,int donemId=0)
        {
            var donemler = await _mediator.Send(new GetDonemlerListQuery());
            if (donemId == 0)
            {
                donemId = donemler.First(x => x.Aktif == true).Id;
            }
            ViewData["DonemId"] = new SelectList(donemler, "Id", "Adi", donemId);
            ViewData["Donem"] = donemId;


            var kurlar =await _mediator.Send(new GetKurlarWithPaginationQuery() { PageNumber = pageNo, PageSize = pageSize ,DonemId = donemId});

            return View(kurlar);
        }

        //public async Task<IActionResult> Index2(int pageNo = 1, int pageSize = 10)
        //{

            //ViewBag.PageSize = pageSize;

            //var vm = new KurListVM
            //{
            //    Kurlar = await _mediator.Send(new GetKurlarListQuery()),
            //};



            //StringBuilder param = new StringBuilder();
            //param.Append("/Kurlar?pageNo=:");
            //param.Append("&pageSize=");
            //param.Append(pageSize);


            //var totalItems = vm.Kurlar.Count();

            //vm.PagingInfo = new Models.PagingInfo
            //{
            //    CurrentPage = pageNo,
            //    ItemsPerPage = pageSize,
            //    TotalItems = totalItems,
            //    UrlParam = param.ToString()
            //};

            //vm.Kurlar = vm.Kurlar.OrderBy(k => k.Id)
            //    .Skip((pageNo - 1) * pageSize)
            //    .Take(pageSize)
            //    .ToList();

            //return View();

            //return View(await _mediator.Send(new GetKurlarListQuery()));
        //}

        public async Task<IActionResult> Yeni()
        {
            var vm = new KurVM();
            ViewData["DonemId"] = new SelectList(await _mediator.Send(new GetDonemlerListQuery()), "Id", "Adi");
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Yeni(KurVM vm)
        {
            if (ModelState.IsValid)
            {

                var result = await _mediator.Send(new CreateKurCommand { Adi = vm.Adi, Aciklama = vm.Aciklama, HDersSaati = vm.HDersSaati, Devamsizlik = vm.Devamsizlik, DgsDevamsizlik = vm.DgsDevamsizlik, DonemId = vm.DonemId });
                TempData["edit"] = $"{vm.Adi} başarıyla kaydedildi.";
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        public async Task<IActionResult> Duzenle(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var kur = await _mediator.Send(new GetKurByIdQuery() { Id = id.Value });
            if (kur == null)
            {
                return NotFound();
            }

            var vm = new KurVM
            {
                Id = kur.Id,
                Adi = kur.Adi,
                HDersSaati = kur.HDersSaati,
                Devamsizlik = kur.DevamsizlikSaati,
                DgsDevamsizlik = kur.DGSDevamsizlikSaati,
                DonemId = kur.DonemId
            };

            var donemler = await _mediator.Send(new GetDonemlerListQuery());

            ViewData["DonemId"] = new SelectList(donemler, "Id", "Adi", vm.DonemId);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(KurVM vm)
        {
            if (ModelState.IsValid)
            {

                var result = await _mediator.Send(new UpdateKurCommand { Id = vm.Id, Adi = vm.Adi, Aciklama = vm.Aciklama, HDersSaati = vm.HDersSaati, Devamsizlik = vm.Devamsizlik, DgsDevamsizlik = vm.DgsDevamsizlik, DonemId = vm.DonemId });
                TempData["edit"] = $"{vm.Adi} başarıyla güncellendi.";
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }


        public async Task<IActionResult> Sil(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var kur = await _mediator.Send(new GetKurByIdQuery() { Id = id.Value });
            if (kur == null)
            {
                return NotFound();
            }

            var vm = new KurVM
            {
                Id = kur.Id,
                Adi = kur.Adi,
                HDersSaati = kur.HDersSaati,
                Devamsizlik = kur.DevamsizlikSaati,
                DgsDevamsizlik = kur.DGSDevamsizlikSaati,
                DonemId = kur.DonemId
            };

            var donemler = await _mediator.Send(new GetDonemlerListQuery());

            ViewData["DonemId"] = new SelectList(donemler, "Id", "Adi", kur.DonemId);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            await _mediator.Send(new DeleteKurCommand() { Id = id });
            TempData["delete"] = "Kur başarıyla silindi";
            return RedirectToAction(nameof(Index));

        }

    }
}
