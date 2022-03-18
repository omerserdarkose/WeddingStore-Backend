using HelenSposa.Core.Entities.Concrete;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.Entities.Dtos.Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Entities.Dtos.User;

namespace HelenSposa.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<ClaimShowDto>> GetUserClaims(int id);
        IDataResult<List<UserShowDto>> GetAll();
        IDataResult<UserShowDto> GetById(int id);
        IResult Add(UserAddDto userAddDto);
        User GetByMail(string eMail);
        IResult Delete(int id);
        IResult Update(int id,UserUpdateDto userUpdateDto);
        IResult AddUserClaim(int id, int claimId);
        IResult DeleteUserClaim(int id, int claimId);
        IResult UserNotExists(string email);
        //IResult SetClaims (User user, List<OperationClaim> operationClaims);
        //kullaniciya yetki ilaveleri yapan bir method yazilacak, user ile ilgili diger 2 tablo dahil edildikten sonra
    }
}
