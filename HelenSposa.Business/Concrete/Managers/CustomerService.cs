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

namespace HelenSposa.Business.Concrete.Managers
{
    class CustomerService : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [FluentValidationAspect(typeof(CustomerValidator))]
        public void Add(Customer addedT)
        {
            _customerDal.Add(addedT);
        }

        public void Delete(Customer deletedT)
        {
            _customerDal.Delete(deletedT);
        }

        public List<Customer> GetAll()
        {
             return _customerDal.GetList();
        }

        public List<Customer> GetAllByPhoneCode(string phoneCode)
        {
            return _customerDal.GetList(c=>c.PhoneCode==phoneCode);
        }
        
        public Customer GetById(int id)
        {
            return _customerDal.Get(c => c.Id == id);
        }

        [FluentValidationAspect(typeof(CustomerValidator))]
        public void Update(Customer updatedT)
        {
            _customerDal.Update(updatedT);
        }
    }
}
