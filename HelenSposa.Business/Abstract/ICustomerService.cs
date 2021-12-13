using HelenSposa.Entities.Concrete;
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

        void Add(Customer addedCustomer);

        void Update(Customer updatedCustomer);

        void Delete(Customer deletedCustomer);
    }
}
