using HelenSposa.Business.Abstract;
using HelenSposa.Business.Aspects.Autofac;
using HelenSposa.Business.Constant;
using HelenSposa.Core.Aspects.Autofac;
using HelenSposa.Core.Entities.Concrete;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Dtos.Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HelenSposa.Business.ValidationRules.FluentValidation;
using HelenSposa.Core.Extensions;
using HelenSposa.Core.Utilities.Security.Hashing;
using HelenSposa.Core.Utilities.Security.PasswordCreator;
using HelenSposa.Entities.Dtos.User;
using Microsoft.AspNetCore.Http;


namespace HelenSposa.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        private IUserClaimService _userClaimManager;
        private IClaimService _claimManager;

        public UserManager(IUserDal userDal, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserClaimService userClaimManager, IClaimService claimManager)
        {
            _userDal = userDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userClaimManager = userClaimManager;
            _claimManager = claimManager;
        }

        //[ValidationAspect(typeof(UserAddValidator))]
        public IDataResult<List<UserShowDto>> GetAll()
        {
            var userList = _userDal.GetList();

            var mapUserList = _mapper.Map<List<UserShowDto>>(userList);

            foreach (UserShowDto user in mapUserList)
            {
                user.Claims = GetUserClaims(user.Id).Data;
            }

            return new SuccessDataResult<List<UserShowDto>>(mapUserList);
        }

        public IDataResult<UserShowDto> GetById(int id)
        {
            var user = _userDal.Get(x => x.Id == id);

            if (user is null)
            {
                return new ErrorDataResult<UserShowDto>(Messages.UserNotFoundById);
            }

            var mapUser = _mapper.Map<UserShowDto>(user);

            mapUser.Claims = GetUserClaims(user.Id).Data;

            return new SuccessDataResult<UserShowDto>(mapUser);
        }

        public IResult Add(UserAddDto userAddDto)
        {

            byte[] passwordHash, passwordSalt;

            var password = PasswordHelper.CreatePassword();

            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var newUser = _mapper.Map<User>(userAddDto);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            newUser.IsActive = true;
            newUser.IuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            newUser.Idate = DateTime.Now;

            _userDal.Add(newUser);
            return new SuccessResult(Messages.UserAdded);
        }

        //[SecuredOperation(roles:"admin")]
        //[CacheRemoveAscpect("IUserService.Get")]
        public IResult Delete(int id)
        {
            var user = _userDal.Get(x => x.Id == id);

            if (user is null)
            {
                return new ErrorResult(Messages.UserNotFoundById);
            }

            user.IsActive = false;
            user.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            user.Udate=DateTime.Now;

            _userDal.Update(user);

            return new SuccessResult(Messages.UserRemoved);
        }

        public IResult Update(int id, UserUpdateDto userUpdateDto)
        {
            var user = _userDal.Get(x => x.Id == id);

            if (user is null)
            {
                return new ErrorResult(Messages.UserNotFoundById);
            }

            user = _mapper.Map(userUpdateDto, user);
            user.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            user.Udate = DateTime.Now;

            _userDal.Update(user);

            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult AddUserClaim(int id, int claimId)
        {
            if (!_userDal.Any(x => x.Id == id))
            {
                return new ErrorResult(Messages.UserNotFoundById);
            }

            if (!_claimManager.CheckClaimById(claimId))
            {
                return new ErrorResult(Messages.ClaimNotFoundById);
            }

            var result=_userClaimManager.Add(id, claimId);

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            return new SuccessResult(result.Message);
        }

        public IResult DeleteUserClaim(int id, int claimId)
        {
            if (!_userDal.Any(x => x.Id == id))
            {
                return new ErrorResult(Messages.UserNotFoundById);
            }

            if (!_claimManager.CheckClaimById(claimId))
            {
                return new ErrorResult(Messages.ClaimNotFoundById);
            }

            var result = _userClaimManager.Delete(id, claimId);

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            return new SuccessResult(result.Message);
        }

        public IResult PasswordReset(string mail)
        {
            var user = GetByMail(mail);

            if (user is null)
            {
                return new ErrorResult(Messages.UserNotFoundByMail);
            }

            var newPassword = PasswordHelper.CreatePassword();

            HashingHelper.CreatePasswordHash(newPassword, out var passwordHash, out var passwordSalt);

            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            user.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId()==0?user.Id: _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            user.Udate=DateTime.Now;

            _userDal.Update(user);

            return new SuccessResult(Messages.UserPasswordReseted);
        }

        //[CacheAspect(duration: 5)]
        public User GetByMail(string eMail)
        {
            var user = _userDal.Get(u => u.Email == eMail);
            return user;
        }

        //[CacheAspect(duration: 5)]
        public IDataResult<List<ClaimShowDto>> GetUserClaims(int id)
        {
            var claims = _userClaimManager.GetClaimsById(id);
            return new SuccessDataResult<List<ClaimShowDto>>(claims);
        }

        //[CacheAspect(duration: 5)]
        public IResult UserNotExists(string email)
        {
            var user = _userDal.Get(u => u.Email == email);
            if (user is not null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }

            return new SuccessResult();
        }

    }
}
