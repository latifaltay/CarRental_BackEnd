using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        private readonly IQueryable<Car> _car;
        private readonly IQueryable<Customer> _customer;

        public RentalValidator(IQueryable<Car> car, IQueryable<Customer> customer)
        {
            _car = car;
            _customer = customer;
            RuleFor(x => x.RentDate).LessThanOrEqualTo(DateTime.Now).WithMessage("RentDate cannot be in the future.");
            RuleFor(x => x.ReturnDate).GreaterThan(rental => rental.RentDate).When(rental => rental.ReturnDate.HasValue).WithMessage("ReturnDate must be after RentDate.");
            RuleFor(x => x.CarId).Must(IsCarAvailable).WithMessage("The specified car could not be found");
            RuleFor(x => x.CarId).Must(IsCustomerAvailable).WithMessage("The specified customer could not be found");
            RuleFor(x => x.RentDate).LessThanOrEqualTo(DateTime.Now).WithMessage("RentDate cannot be in the future.");
            RuleFor(x => x.ReturnDate).GreaterThan(x => x.RentDate).When(x => x.ReturnDate.HasValue).WithMessage("ReturnDate must be after RentDate.");
        }

        private bool IsCarAvailable(int id)
        {
            return _car.Any(brand => brand.Id == id);
        }

        private bool IsCustomerAvailable(int id)
        {
            return _car.Any(brand => brand.Id == id);
        }

    }
}
