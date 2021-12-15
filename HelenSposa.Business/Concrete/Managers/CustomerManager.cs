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
using HelenSposa.Entities.Dtos;
using AutoMapper;

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
        public void Add(CustomerAddDto addedT)
        {
            _customerDal.Add(_mapper.Map<Customer>(addedT));
        }

        public void Delete(Customer deletedT)
        {
            _customerDal.Delete(deletedT);
        }

        public List<Customer> GetAll()
        {
             return _customerDal.GetList();
        }

        /// <summary>
        /// ulke telefon kodlarina gore musterileri getirir
        /// </summary>
        /// <param name="phoneCode">ulke telefon kodu</param>
        /// <returns>musteri listesi doner </returns>
        public List<Customer> GetAllByPhoneCode(string phoneCode)
        {
            return _customerDal.GetList(c=>c.PhoneCode==phoneCode);
        }
        
        public Customer GetById(int id)
        {
            return _customerDal.Get(c => c.Id == id);
        }

        public Customer FindPhone(string phoneNu)
        {
            return _customerDal.Get(c => c.PhoneNumber == phoneNu);
        }
        
        
        [FluentValidation(typeof(CustomerValidator))]
        public void Update(CustomerUpdateDto updatedT)
        {
            _customerDal.Update(_mapper.Map<Customer>(updatedT));
        }
    }
}
