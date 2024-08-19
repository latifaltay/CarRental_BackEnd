using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator() 
        {
            RuleFor(brand => brand.Name).NotNull().WithMessage("Brand name cannot be null.");
            RuleFor(brand => brand.Name).NotEmpty().WithMessage("Brand name cannot be empty.");
            RuleFor(brand => brand.Name).MinimumLength(2).WithMessage("Brand name must be at least 2 characters long.");
            RuleFor(brand => brand.Name).MaximumLength(50).WithMessage("Brand name must be at most 50 characters long.");
        }
    }
}
