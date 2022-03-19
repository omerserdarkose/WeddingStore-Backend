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
    public class ClaimManager:IClaimService
    {
        private IClaimDal _claimDal;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;

        public ClaimManager(IClaimDal claimDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _claimDal = claimDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IDataResult<List<ClaimShowDto>> GetAll()
        {
            var claimList = _claimDal.GetList();
            var claimShowList = _mapper.Map<List<ClaimShowDto>>(claimList);

            return new SuccessDataResult<List<ClaimShowDto>>(claimShowList);

        }

        public IDataResult<ClaimShowDto> GetById(int id)
        {
            var claim = _claimDal.Get(x => x.Id == id);

            if (claim is null)
            {
                return new ErrorDataResult<ClaimShowDto>(Messages.ClaimNotFoundById);
            }

            var claimShow = _mapper.Map<ClaimShowDto>(claim);

            return new SuccessDataResult<ClaimShowDto>(claimShow);
        }

        public bool CheckClaimById(int id)
        {
            var claimCheck = _claimDal.Any(x => x.Id == id);

            return claimCheck;
        }

        public IResult Add(string claimName)
        {
            var checkClaim = _claimDal.Any(x => x.Name == claimName);
            if (checkClaim)
            {
                return new ErrorResult(Messages.ClaimAlreadyExists);
            }

            var newClaim = new Claim()
            {
                Name = claimName,
                IsActive = true,
                IuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId(),
                Idate = DateTime.Now
            };

            _claimDal.Add(newClaim);

            return new SuccessResult(Messages.ClaimAdded);
        }

        public IResult Delete(int id)
        {
            var claim = _claimDal.Get(x => x.Id == id);

            if (claim is null)
            {
                return new ErrorResult(Messages.ClaimNotFoundById);
            }

            claim.IsActive = false;
            claim.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            claim.Udate=DateTime.Now;

            _claimDal.Update(claim);

            return new SuccessResult(Messages.ClaimRemoved);

        }

        public IResult Update(ClaimUpdateDto claimUpdateDto)
        {
            var claim = _claimDal.Get(x => x.Id == claimUpdateDto.Id);

            if (claim is null)
            {
                return new ErrorResult(Messages.ClaimNotFoundById);
            }

            claim = _mapper.Map(claimUpdateDto, claim);

            _claimDal.Update(claim);

            return new SuccessResult(Messages.ClaimUpdated);
        }
    }
}
