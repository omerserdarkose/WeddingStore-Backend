using AutoMapper;
using HelenSposa.Business.Abstract;
using HelenSposa.Business.Aspects.Autofac;
using HelenSposa.Business.Constant;
using HelenSposa.Business.ValidationRules.FluentValidation;
using HelenSposa.Core.Aspects.Autofac;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.ExpenseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace HelenSposa.Business.Concrete.Managers
{
    public class ExpenseTypeManager : IExpenseTypeService
    {
        private IExpenseTypeDal _expenseTypeDal;
        private IHttpContextAccessor _httpContextAccessor;
        private IMapper _mapper;

        public ExpenseTypeManager(IExpenseTypeDal expenseTypeDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _expenseTypeDal = expenseTypeDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        //[SecuredOperation("admin")]
        //[ValidationAspect(typeof(ExpenseTypeAddValidator))]
        //[CacheRemoveAscpect("IExpenseTypeService.Get")]
        public IResult Add(ExpenseTypeAddDto addedExpenseType)
        {
            var newExpenseType = _mapper.Map<ExpenseType>(addedExpenseType);
            newExpenseType.Idate=DateTime.Now;
            newExpenseType.IuserId= _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            _expenseTypeDal.Add(newExpenseType);
            newExpenseType.IsActive = true;
            return new SuccessResult(Messages.ExpenseTypeAdded);
        }

        //[SecuredOperation("admin")]
        //[CacheRemoveAscpect("IExpenseTypeService.Get")]
        public IResult Delete(int id)
        {
            var delExpenseType = _expenseTypeDal.Get(x => x.Id == id);
            if (delExpenseType is null)
            {
                return new ErrorResult(Messages.ExpenseTypeNotFound);
            }
            delExpenseType.UuserId= _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            delExpenseType.Udate=DateTime.Now;
            delExpenseType.IsActive = false;
            _expenseTypeDal.Update(delExpenseType);
            return new SuccessResult(Messages.ExpenseTypeDeleted);
        }

        //[SecuredOperation("admin,worker")]
        //[CacheAspect(duration: 10)]
        public IDataResult<List<ExpenseTypeShowDto>> GetAll()
        {
            var expenseTypeList = _expenseTypeDal.GetList();
            var mapExpenseTypeList = _mapper.Map<List<ExpenseTypeShowDto>>(expenseTypeList);
            return new SuccessDataResult<List<ExpenseTypeShowDto>>(mapExpenseTypeList);
        }

        //[SecuredOperation("admin")]
        //[ValidationAspect(typeof(ExpenseTypeUpdateValidator))]
        //[CacheRemoveAscpect("IExpenseTypeService.Get")]
        public IResult Update(int id,ExpenseTypeUpdateDto updatedExpenseType)
        {
            var updExpenseType = _expenseTypeDal.Get(x => x.Id == id);
            if (updExpenseType is null)
            {
                return new ErrorResult(Messages.ExpenseTypeNotFound);
            }
            updExpenseType = _mapper.Map(updatedExpenseType,updExpenseType);
            updExpenseType.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            updExpenseType.Udate=DateTime.Now;
            _expenseTypeDal.Update(updExpenseType);
            return new SuccessResult(Messages.ExpenseTypeUpdated);
        }
    }
}
