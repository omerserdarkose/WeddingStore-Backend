using AutoMapper;
using HelenSposa.Core.Entities.Concrete;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Customer;
using HelenSposa.Entities.Dtos.ExpenseType;
using HelenSposa.Entities.Dtos.Claim;
using HelenSposa.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Entities.Dtos.EventType;
using HelenSposa.Entities.Dtos.Expense;
using HelenSposa.Entities.Dtos.Product;

namespace HelenSposa.Business.Mapping.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerAddDto, Customer>().ReverseMap();
            
            CreateMap<CustomerUpdateDto, Customer>().ReverseMap();

            CreateMap<CustomerDeleteDto, Customer>().ReverseMap();

            CreateMap<CustomerShowDto, Customer>().ReverseMap();

            CreateMap<ExpenseTypeShowDto, ExpenseType>().ReverseMap(); 
            CreateMap<ExpenseTypeAddDto, ExpenseType>().ReverseMap();
            CreateMap<ExpenseTypeUpdateDto, ExpenseType>().ReverseMap();

            CreateMap<EventTypeShowDto, EventType>().ReverseMap();
            CreateMap<EventTypeAddDto, EventType>().ReverseMap();
            CreateMap<EventTypeUpdateDto, EventType>().ReverseMap();

            CreateMap<ExpenseAddDto, Expense>().ReverseMap();
            CreateMap<ExpenseShowDto, Expense>().ReverseMap();
            CreateMap<ExpenseUpdateDto, Expense>().ReverseMap();

            CreateMap<ProductShowDto, Product>().ReverseMap();
            CreateMap<ProductAddDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();

            CreateMap<UserAddDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserShowDto>();
            
            CreateMap<ClaimShowDto, Claim>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ClaimName)).ReverseMap();

            CreateMap<ClaimUpdateDto, Claim>().ReverseMap();


        }
    }
}
