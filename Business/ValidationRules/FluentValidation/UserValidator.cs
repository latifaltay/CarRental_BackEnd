using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName cannot be empty.");
            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage("FirstName must be at least 2 characters long.");
            RuleFor(x => x.FirstName).MaximumLength(50).WithMessage("FirstName cannot be longer than 50 characters.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName cannot be empty.");
            RuleFor(x => x.LastName).MinimumLength(2).WithMessage("LastName must be at least 2 characters long.");
            RuleFor(x => x.LastName).MaximumLength(50).WithMessage("LastName cannot be longer than 50 characters.");


            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("Email cannot be longer than 100 characters.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty.");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
            RuleFor(x => x.Password).MaximumLength(50).WithMessage("Password cannot be longer than 50 characters.");
            RuleFor(x => x.Password).Matches(@"\d").WithMessage("Password must contain at least one number.");

            RuleFor(x => x.Password).Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.");

            RuleFor(x => x.Password).Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.");

            RuleFor(x => x.Password).Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");

            RuleFor(x => new{ x.FirstName, x.LastName}).Must(x => (x.FirstName.Length + x.LastName.Length) <= 100).WithMessage("Combined length of FirstName and LastName cannot exceed 100 characters.");

            RuleFor(x => x.customer).NotNull().WithMessage("Customer information is required.");
        }
    }
}
