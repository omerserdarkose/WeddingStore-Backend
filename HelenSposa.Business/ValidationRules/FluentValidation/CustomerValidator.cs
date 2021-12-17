using FluentValidation;
using HelenSposa.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("Customer Name cannot be empty");
            RuleFor(c => c.FirstName).Length(2,30).WithMessage("Customer Name length must be between 2 and 30 characters");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Customer Surname cannot be empty");
            RuleFor(c => c.LastName).Length(2, 30).WithMessage("Customer Surname length must be between 2 and 30 characters");
            RuleFor(c => c.PhoneCode).NotEmpty().WithMessage("Country Phone Code cannot be empty");
            RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("Customer Phone Number cannot be empty");
            RuleFor(c => c.PhoneNumber).Matches(@"^((\d{3})(\d{3})(\d{2})(\d{2}))$").When(c => c.PhoneCode == "+90").WithMessage("Please write the customer's phone number as 10 digits without leading 0");
        }
    }
}
