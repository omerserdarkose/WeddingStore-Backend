using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HelenSposa.Business.Abstract;
using HelenSposa.Business.Constant;
using HelenSposa.Core.Entities.Concrete;
using HelenSposa.Core.Extensions;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Dtos.Claim;
using Microsoft.AspNetCore.Http;

namespace HelenSposa.Business.Concrete.Managers
{
    public class UserClaimManager:IUserClaimService
    {
        private IUserClaimDal _userClaimDal;
        private IHttpContextAccessor _httpContextAccessor;
        private IMapper _mapper;

        public UserClaimManager(IUserClaimDal userClaimDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userClaimDal = userClaimDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<ClaimShowDto> GetClaimsById(int id)
        {
            var userClaimList = _userClaimDal.GetClaims(id);
            return userClaimList;
        }
        
        public IResult Add(int id, int claimId)
        {
            var userClaim = _userClaimDal.Get(x => x.UserId == id && x.ClaimId == claimId);

            if (userClaim is not null)
            {
                return new ErrorResult(Messages.UserClaimAlreadyExists);
            }

            userClaim = new UserClaim()
            {
                UserId = id,
                ClaimId = claimId,
                IuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId(),
                Idate = DateTime.Now
            };

            _userClaimDal.Add(userClaim);

            return new SuccessResult(Messages.UserClaimAdded);
        }

        public IResult Delete(int id, int claimId)
        {
            var userClaim = _userClaimDal.Get(x => x.UserId == id && x.ClaimId == claimId);

            if (userClaim is null)
            {
                return new ErrorResult(Messages.UserClaimNotFound);
            }

            _userClaimDal.Delete(userClaim);

            return new SuccessResult(Messages.UserClaimDeleted);
        }
    }
}
