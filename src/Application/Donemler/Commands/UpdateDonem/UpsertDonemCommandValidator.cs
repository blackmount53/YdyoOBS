using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YdyoOBS.Application.Donemler.Commands.UpdateDonem
{
    public class UpsertDonemCommandValidator: AbstractValidator<UpsertDonemCommand>
    {
        public UpsertDonemCommandValidator()
        {           
            RuleFor(x => x.Adi).MinimumLength(4).NotEmpty();            
        }
    }
}
