using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
        private readonly ICarDal _carDal;

        public RentalValidator(ICarDal carDal)
        {
            _carDal = carDal;

            RuleFor(x => x.RentDate).LessThanOrEqualTo(DateTime.Now).WithMessage("RentDate cannot be in the future.");
            RuleFor(x => x.ReturnDate).GreaterThan(rental => rental.RentDate).When(rental => rental.ReturnDate.HasValue).WithMessage("ReturnDate must be after RentDate.");
            RuleFor(x => x.RentDate).LessThanOrEqualTo(DateTime.Now).WithMessage("RentDate cannot be in the future.");
            RuleFor(x => x.ReturnDate).GreaterThan(x => x.RentDate).When(x => x.ReturnDate.HasValue).WithMessage("ReturnDate must be after RentDate.");
            RuleFor(c => c.Id).Must(_carDal.IsCarAvailable).WithMessage("This car is not available.");
        }
    }
}
