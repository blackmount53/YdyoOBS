using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YdyoOBS.WebUI.Views.Shared.Components.FormModal
{
    public class FormModalViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
