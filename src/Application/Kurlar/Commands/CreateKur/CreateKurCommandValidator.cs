using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YdyoOBS.Application.Kurlar.Commands.CreateKur
{
    public class CreateKurCommandValidator : AbstractValidator<CreateKurCommand>
    {
        public CreateKurCommandValidator()
        {
            RuleFor(x => x.Adi).NotEmpty();
            RuleFor(x => x.DonemId).NotNull();
        }
    }
}
