using FluentValidation;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.ExpenseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.ValidationRules.FluentValidation
{
    public class ExpenseTypeAddValidator:AbstractValidator<ExpenseTypeAddDto>
    {
        public ExpenseTypeAddValidator()
        {
            RuleFor(et => et.Name).Length(2, 15).WithMessage("Gider Türü ismi 2 ile 15 karakter arasında olabilir");
            RuleFor(et => et.Name).Matches(@"^[a-zA-Z]*\s{0,1}[a-zA-Z]*$").WithMessage("Isim yalnizca harflerden olusabilir ve max 2 kelime olabilir");
        }
    }
}
