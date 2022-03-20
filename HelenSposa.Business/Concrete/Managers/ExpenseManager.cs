using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HelenSposa.Business.Abstract;
using HelenSposa.Business.Constant;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Dtos.Expense;

namespace HelenSposa.Business.Concrete.Managers
{
    public class ExpenseManager:IExpenseService
    {
        private IExpenseDal _expenseDal;
        private IExpenseTypeService _expenseTypeManager;
        private IMapper _mapper;

        public ExpenseManager(IExpenseDal expenseDal, IExpenseTypeService expenseTypeManager, IMapper mapper)
        {
            _expenseDal = expenseDal;
            _expenseTypeManager = expenseTypeManager;
            _mapper = mapper;
        }

        public IDataResult<List<ExpenseShowDto>> GetAll(Expression<Func<ExpenseShowDto, bool>> filter = null)
        {
            var expenseList = _expenseDal.GetShowList(filter);

            if (expenseList is null)
            {
                return new ErrorDataResult<List<ExpenseShowDto>>(Messages.ExpenseNotExists);
            }

            return new SuccessDataResult<List<ExpenseShowDto>>(expenseList);
        }

        public IDataResult<List<ExpenseShowDto>> GetAllByTypeId(int typeId)
        {
            var check = _expenseTypeManager.IsExists(typeId);

            if (!check)
            {
                return new ErrorDataResult<List<ExpenseShowDto>>(Messages.ExpenseTypeNotFound);
            }

            var expenseList = _expenseDal.GetList(x => x.TypeId == typeId);

            if (expenseList is null)
            {
                return new ErrorDataResult<List<ExpenseShowDto>>(Messages.ExpenseNotExistsByCategory);
            }

            var expenseShowList = _mapper.Map<List<ExpenseShowDto>>(expenseList);

            return new SuccessDataResult<List<ExpenseShowDto>>(expenseShowList);
        }
    }
}
