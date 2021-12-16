using AutoMapper;
using HelenSposa.Business.Abstract;
using HelenSposa.Business.Constant;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos;
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

        public IResult Add(ExpenseTypeGeneralDto addedExpenseType)
        {
            var mapExpenseType = _mapper.Map<ExpenseType>(addedExpenseType);
            _expenseTypeDal.Add(mapExpenseType);
            return new SuccessResult(Messages.ExpenseTypeAdded);
        }

        public IResult Delete(ExpenseTypeGeneralDto deletedExpenseType)
        {
            var mapExpenseType = _mapper.Map<ExpenseType>(deletedExpenseType);
            _expenseTypeDal.Delete(mapExpenseType);
            return new SuccessResult(Messages.ExpenseTypeDeleted);
        }

        public IDataResult<List<ExpenseTypeGeneralDto>> GetAll()
        {
            var expenseTypeList = _expenseTypeDal.GetList();
            var mapExpenseTypeList = _mapper.Map<List<ExpenseTypeGeneralDto>>(expenseTypeList);
            return new SuccessDataResult<List<ExpenseTypeGeneralDto>>(mapExpenseTypeList);
        }

        public IResult Update(ExpenseTypeGeneralDto updatedExpenseType)
        {
            var mapExpenseType = _mapper.Map<ExpenseType>(updatedExpenseType);
            _expenseTypeDal.Update(mapExpenseType);
            return new SuccessResult(Messages.ExpenseTypeUpdated);
        }
    }
}
