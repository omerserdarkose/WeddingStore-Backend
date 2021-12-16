using HelenSposa.Core.Utilities.Result;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<CustomerShowDto>> GetAll();

        IDataResult<CustomerShowDto> GetById(int id);

        IDataResult<Customer> FindPhone(string phoneNu);

        IResult Add(CustomerAddDto addedCustomer);

        IResult Update(CustomerUpdateDto updatedCustomer);

        IResult Delete(CustomerDeleteDto deletedCustomer);
    }
}
