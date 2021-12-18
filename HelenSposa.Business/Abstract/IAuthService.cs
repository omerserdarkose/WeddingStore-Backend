using HelenSposa.Core.Entities.Concrete;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.Core.Utilities.Security;
using HelenSposa.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Resgister(UserRegisterDto userRegisterDto, string password);

        IDataResult<User> Login(UserLoginDto userLoginDto);

        IResult UserExists(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
