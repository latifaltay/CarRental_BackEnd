using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        private readonly IQueryable<Brand> _brand;
        public CarValidator(IQueryable<Brand> brand) 
        {
            _brand = brand;

            RuleFor(x => x.Name).NotNull().WithMessage("Car name cannot be null.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Car name cannot be empty.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Car name must be at least 2 characters long.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Car name must be at most 50 characters long.");
            RuleFor(x => x.BrandId).Must(IsNotBrand).WithMessage("There is no brand");
            RuleFor(x => x.ModelYear).LessThan(DateTime.Now.Year + 1).WithMessage("The car can be " + DateTime.Now.Year + "model");
            RuleFor(x => x.DailyPrice).GreaterThan(0).WithMessage("Sıfırdan büyük olmalı");
            RuleFor(x => x.Description).NotNull().WithMessage("Description name cannot be null.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description name cannot be empty.");
        }

        private bool IsNotBrand(int id) 
        {
            return _brand.Any(brand => brand.Id == id);
        }

    }
}
