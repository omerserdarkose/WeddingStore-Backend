using HelenSposa.Core.Entities.Concrete;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.Entities.Dtos.OperationClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaimShowDto>> GetClaims(User user);

        IResult Add(User addUser);

        IDataResult<User> GetByMail(string eMail);
    }
}
