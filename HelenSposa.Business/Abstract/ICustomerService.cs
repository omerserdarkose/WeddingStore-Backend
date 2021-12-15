using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();

        List<Customer> GetAllByPhoneCode(string phoneCode);

        Customer GetById(int id);

        Customer FindPhone(string phoneNu);

        void Add(CustomerAddDto addedCustomer);

        void Update(CustomerUpdateDto updatedCustomer);

        void Delete(Customer deletedCustomer);
    }
}
