using HelenSposa.Business.Abstract;
using HelenSposa.Business.ValidationRules.FluentValidation;
using HelenSposa.Core.CrossCuttingConcerns.Validation.FluentValidation;
using HelenSposa.Core.Aspects.Postsharp;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Entities.Dtos.Customer;
using AutoMapper;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.Business.Constant;

namespace HelenSposa.Business.Concrete.Managers
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        private IMapper _mapper;


        public CustomerManager(ICustomerDal customerDal, IMapper mapper)
        {
            _customerDal = customerDal;
            _mapper = mapper;
        }

        //attribute calismiyor suan postsharp activation ile ilgili bir problem var tekrar bakilmali
        [FluentValidation(typeof(CustomerValidator))]
        public IResult Add(CustomerAddDto addedCustomer)
        {
            var mapCustomer=_mapper.Map<Customer>(addedCustomer);
            _customerDal.Add(mapCustomer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(CustomerDeleteDto deletedCustomer)
        {
            var mapCustomer = _mapper.Map<Customer>(deletedCustomer);
            _customerDal.Delete(mapCustomer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<CustomerShowDto>> GetAll()
        {
            var customerList=_customerDal.GetList();
            var mapCustomerList= _mapper.Map<List<CustomerShowDto>>(customerList);
            return new SuccessDataResult<List<CustomerShowDto>>(mapCustomerList);
        }

     
        public IDataResult<CustomerShowDto> GetById(int id)
        {
            var customer = _customerDal.Get(c => c.Id == id);
            var mapCustomer = _mapper.Map<CustomerShowDto>(customer);
            return new SuccessDataResult<CustomerShowDto>(mapCustomer);
        }

        public IDataResult<Customer> FindPhone(string phoneNu)
        {
            var customer = _customerDal.Get(c => c.PhoneNumber == phoneNu);
            return new SuccessDataResult<Customer>(customer);
        }
        
        
        [FluentValidation(typeof(CustomerValidator))]
        public IResult Update(CustomerUpdateDto updatedCustomer)
        {
            var mapCustomer = _mapper.Map<Customer>(updatedCustomer);
            _customerDal.Update(mapCustomer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
