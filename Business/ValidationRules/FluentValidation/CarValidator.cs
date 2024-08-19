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

            RuleFor(car => car.Name).NotNull().WithMessage("Car name cannot be null.");
            RuleFor(car => car.Name).NotEmpty().WithMessage("Car name cannot be empty.");
            RuleFor(car => car.Name).MinimumLength(2).WithMessage("Car name must be at least 2 characters long.");
            RuleFor(car => car.Name).MaximumLength(50).WithMessage("Car name must be at most 50 characters long.");
            RuleFor(car => car.BrandId).Must(IsNotBrand).WithMessage("There is no brand");
            RuleFor(car => car.ModelYear).LessThan(DateTime.Now.Year + 1).WithMessage("The car can be " + DateTime.Now.Year + "model");
            RuleFor(car => car.DailyPrice).GreaterThan(0).WithMessage("Sıfırdan büyük olmalı");
            RuleFor(car => car.Description).NotNull().WithMessage("Description name cannot be null.");
            RuleFor(car => car.Description).NotEmpty().WithMessage("Description name cannot be empty.");
        }

        private bool IsNotBrand(int id) 
        {
            return _brand.Any(brand => brand.Id == id);
        }

    }
}
