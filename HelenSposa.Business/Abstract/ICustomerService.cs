using HelenSposa.Core.Business;
using HelenSposa.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Abstract
{
    public interface ICustomerService:IServiceRepository<Customer>
    {
        Customer GetById(int id);

        List<Customer> GetAllByPhoneCode(string phoneCode);
    }
}
