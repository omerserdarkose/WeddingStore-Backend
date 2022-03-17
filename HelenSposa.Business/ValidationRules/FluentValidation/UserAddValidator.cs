using FluentValidation;
using HelenSposa.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.ValidationRules.FluentValidation
{
    public class UserAddValidator:AbstractValidator<UserAddDto>
    {
        public UserAddValidator()
        {
            RuleFor(u => u.FirstName).Length(2,50).WithMessage("Isim 2-50 karakter olabilir");
            RuleFor(u => u.FirstName).Matches(@"^([^0-9]*)$").WithMessage("Isim rakam iceremez");
            RuleFor(u => u.LastName).Length(2, 50).WithMessage("Soy isim 2-50 karakter olabilir");
            RuleFor(u => u.LastName).Matches(@"^([^0-9]*)$").WithMessage("Soy isim rakam iceremez");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Lutfen gecerli bir e-mail adresi giriniz");
        }
    }
}
