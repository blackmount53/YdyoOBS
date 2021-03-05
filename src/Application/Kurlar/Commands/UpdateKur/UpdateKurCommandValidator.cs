using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YdyoOBS.Application.Kurlar.Commands.UpdateKur
{
    public class UpdateKurCommandValidator : AbstractValidator<UpdateKurCommand>
    {
        public UpdateKurCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Adi).NotEmpty();
            RuleFor(x => x.DonemId).NotNull();
        }
    }
}
