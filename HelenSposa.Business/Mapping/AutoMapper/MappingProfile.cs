using AutoMapper;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Customer;
using HelenSposa.Entities.Dtos.Expense;
using HelenSposa.Entities.Dtos.ExpenseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Mapping.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerAddDto, Customer>();
            CreateMap<Customer, CustomerAddDto>();
            
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<Customer, CustomerUpdateDto>();

            CreateMap<CustomerDeleteDto, Customer>();
            CreateMap<Customer, CustomerDeleteDto>();

            CreateMap<CustomerShowDto, Customer>();
            CreateMap<Customer, CustomerShowDto>();

            CreateMap<ExpenseTypeShowDto, ExpenseType>();
            CreateMap<ExpenseType, ExpenseTypeShowDto>();

            CreateMap<ExpenseTypeAddDto, ExpenseType>();
            CreateMap<ExpenseType, ExpenseTypeAddDto>();

            CreateMap<ExpenseTypeDeleteDto, ExpenseType>();
            CreateMap<ExpenseType, ExpenseTypeDeleteDto>();

            CreateMap<ExpenseTypeUpdateDto, ExpenseType>();
            CreateMap<ExpenseType, ExpenseTypeUpdateDto>();

            CreateMap<ExpenseAddDto, Expense>();
            CreateMap<Expense, ExpenseAddDto>();
            
            CreateMap<ExpenseDeleteDto, Expense>();
            CreateMap<Expense, ExpenseDeleteDto>();

            CreateMap<ExpenseUpdateDto, Expense>();
            CreateMap<Expense, ExpenseUpdateDto>();

            //CreateMap<ExpenseShowDto, opt=> { }();

        }
    }
}
