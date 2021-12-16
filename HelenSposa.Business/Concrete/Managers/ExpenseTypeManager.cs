using AutoMapper;
using HelenSposa.Business.Abstract;
using HelenSposa.Business.Constant;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.ExpenseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Concrete.Managers
{
    public class ExpenseTypeManager : IExpenseTypeService
    {
        private IExpenseTypeDal _expenseTypeDal;
        private IMapper _mapper;

        public ExpenseTypeManager(IExpenseTypeDal expenseTypeDal, IMapper mapper)
        {
            _expenseTypeDal = expenseTypeDal;
            _mapper = mapper;
        }

        public IResult Add(ExpenseTypeAddDto addedExpenseType)
        {
            var mapExpenseType = _mapper.Map<ExpenseType>(addedExpenseType);
            _expenseTypeDal.Add(mapExpenseType);
            return new SuccessResult(Messages.ExpenseTypeAdded);
        }

        public IResult Delete(ExpenseTypeDeleteDto deletedExpenseType)
        {
            var mapExpenseType = _mapper.Map<ExpenseType>(deletedExpenseType);
            _expenseTypeDal.Delete(mapExpenseType);
            return new SuccessResult(Messages.ExpenseTypeDeleted);
        }

        public IDataResult<List<ExpenseTypeShowDto>> GetAll()
        {
            var expenseTypeList = _expenseTypeDal.GetList();
            var mapExpenseTypeList = _mapper.Map<List<ExpenseTypeShowDto>>(expenseTypeList);
            return new SuccessDataResult<List<ExpenseTypeShowDto>>(mapExpenseTypeList);
        }

        public IResult Update(ExpenseTypeUpdateDto updatedExpenseType)
        {
            var mapExpenseType = _mapper.Map<ExpenseType>(updatedExpenseType);
            _expenseTypeDal.Update(mapExpenseType);
            return new SuccessResult(Messages.ExpenseTypeUpdated);
        }
    }
}
