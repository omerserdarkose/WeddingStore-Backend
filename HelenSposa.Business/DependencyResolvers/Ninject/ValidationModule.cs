using FluentValidation;
using HelenSposa.Business.ValidationRules.FluentValidation;
using HelenSposa.Entities.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.DependencyResolvers.Ninject
{
    public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Customer>>().To<CustomerValidator>().InSingletonScope();
        }
    }
}
