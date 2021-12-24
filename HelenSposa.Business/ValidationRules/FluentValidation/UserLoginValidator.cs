using FluentValidation;
using HelenSposa.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.ValidationRules.FluentValidation
{
    public class UserLoginValidator:AbstractValidator<UserLoginDto>
    {
        public UserLoginValidator()
        {
            RuleFor(u => u.Email).EmailAddress().WithMessage("Lutfen gecerli bir e-mail adresi giriniz");
        }
    }
}
