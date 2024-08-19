using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        private readonly IQueryable<Customer> _customer;
        public CustomerValidator(IQueryable<Customer> customer)
        {
            _customer = customer;

            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("CompanyName cannot be empty.");
            RuleFor(x => x.CompanyName).MinimumLength(3).WithMessage("CompanyName must be at least 3 characters long.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }


    }
}
