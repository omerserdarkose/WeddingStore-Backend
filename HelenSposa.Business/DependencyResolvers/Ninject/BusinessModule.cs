using HelenSposa.Business.Abstract;
using HelenSposa.Business.Concrete.Managers;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();

            Bind<ICustomerDal>().To<EfCustomerDal>();

            Bind<IExpenseDal>().To<EfExpenseDal>();

            Bind<DbContext>().To<HelenSposaDbContext>();

        }
    }
}
