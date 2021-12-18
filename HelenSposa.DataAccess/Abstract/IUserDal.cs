using HelenSposa.Core.DataAccess;
using HelenSposa.Core.Entities.Concrete;
using HelenSposa.Entities.Dtos.OperationClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
        List<OperationClaimShowDto> GetClaims(User user);
    }
}
