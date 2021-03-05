using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YdyoOBS.Application.Common.Dto;
using YdyoOBS.Application.Donemler.Commands.UpdateDonem;
using YdyoOBS.Application.Donemler.Queries.GetDonemById;
using YdyoOBS.Application.Donemler.Queries.GetDonemlerList;

namespace YdyoOBS.WebUI.Controllers
{
    public class DonemlerController : Controller
    {
        private readonly IMediator _mediator;

        public DonemlerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetDonemlerListQuery()));
        }


        public async Task<IActionResult> Duzenle(int? id)
        {            
            return View(await _mediator.Send(new GetDonemByIdQuery() { Id = id.Value }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(DonemDto vm)
        {

            if (ModelState.IsValid)
            {
                await _mediator.Send(new UpsertDonemCommand() { Id = vm.Id, Adi = vm.Adi, Aktif = vm.Aktif });
                return RedirectToAction(nameof(Index));
            }

            return View(vm);

        }

    }
}
