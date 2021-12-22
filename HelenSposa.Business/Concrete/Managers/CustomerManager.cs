using HelenSposa.Business.Abstract;
using HelenSposa.Business.ValidationRules.FluentValidation;
using HelenSposa.Core.CrossCuttingConcerns.Validation.FluentValidation;
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
using HelenSposa.Core.Aspects.Autofac;

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


        [ValidationAspect(typeof(CustomerValidator))]
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
            //dataAccess katmanina gidilerek tum musteri listesi getiriliyor
            var customerList=_customerDal.GetList();

            //gelen liste UI da gosterilecek formata map ediliyor
            var mapCustomerList= _mapper.Map<List<CustomerShowDto>>(customerList);

            //map edilmis liste Result ile sarmallanarak api'ye donduruluyor
            return new SuccessDataResult<List<CustomerShowDto>>(mapCustomerList);
        }

     
        public IDataResult<CustomerShowDto> GetById(int id)
        {
            //dataAccess katmanina gidilerek belirtilen id'ye sahip musteri getiriliyor
            var customer = _customerDal.Get(c => c.Id == id);

            //eger musteri id'sinde kayit yoksa
            if (customer==null)
            {
                //api'ye hata mesaji gonderiliyor
                return new ErrorDataResult<CustomerShowDto>(Messages.CustomerNotFound);
            }

            //getirilen kayit UI da gosterilecek formata map ediliyor
            var mapCustomer = _mapper.Map<CustomerShowDto>(customer);

            //map edilmis kayit Result ile sarmallanarak api'ye donduruluyor
            return new SuccessDataResult<CustomerShowDto>(mapCustomer);
        }

        public IDataResult<Customer> FindPhone(string phoneNu)
        {
            var customer = _customerDal.Get(c => c.PhoneNumber == phoneNu);
            return new SuccessDataResult<Customer>(customer);
        }


        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(CustomerUpdateDto updatedCustomer)
        {
            var mapCustomer = _mapper.Map<Customer>(updatedCustomer);
            _customerDal.Update(mapCustomer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
