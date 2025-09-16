using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Dentists.Commands.CreateDentist
{
    public class CreateDentistCommandValidator: AbstractValidator<CreateDentistCommand>
    {
        public CreateDentistCommandValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("The field {PropertyName} is required");

            RuleFor(p => p.Email)
           .NotEmpty().WithMessage("The field {PropertyName} is required")
           .EmailAddress().WithMessage("Invalid email format");

        }
    }
}
