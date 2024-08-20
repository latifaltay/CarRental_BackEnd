using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Entities.Concrete.Color>
    {
        public ColorValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Brand name cannot be null.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Brand name cannot be empty.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Brand name must be at least 2 characters long.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Brand name must be at most 50 characters long.");
        }
    }
}
