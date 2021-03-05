using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YdyoOBS.Application.Common.Dto;

namespace YdyoOBS.WebUI.Models.ViewModels
{
    public class KurListVM
    {
        public List<KurDto> Kurlar { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
