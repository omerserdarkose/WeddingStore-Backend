using Autofac;
using HelenSposa.Business.Abstract;
using HelenSposa.Business.Concrete.Managers;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HelenSposaDbContext>().As<DbContext>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();

            builder.RegisterType<ExpenseTypeManager>().As<IExpenseTypeService>();
            builder.RegisterType<EfExpenseTypeDal>().As<IExpenseTypeDal>();

            builder.RegisterType<ExpenseManager>().As<IExpenseService>();
            builder.RegisterType<EfExpenseDal>().As<IExpenseDal>();
        }
    }
}
