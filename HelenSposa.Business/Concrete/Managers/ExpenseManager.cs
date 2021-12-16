using AutoMapper;
using HelenSposa.Business.Abstract;
using HelenSposa.Business.Constant;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Concrete.Managers
{
    public class ExpenseManager : IExpenseService
    {
        private IExpenseDal _expenseDal;
        private IMapper _mapper;

        public ExpenseManager(IExpenseDal expenseDal, IMapper mapper)
        {
            _expenseDal = expenseDal;
            _mapper = mapper;
        }

        public IResult Add(ExpenseAddDto addedExpense)
        {
            var mapExpense = _mapper.Map<Expense>(addedExpense);
            _expenseDal.Add(mapExpense);
            return new SuccessResult(Messages.ExpenseAdded);
        }

        public IResult Delete(ExpenseDeleteDto deletedExpense)
        {
            var mapExpense = _mapper.Map<Expense>(deletedExpense);
            _expenseDal.Delete(mapExpense);
            return new SuccessResult(Messages.ExpenseDeleted);
        }

        public IDataResult<List<ExpenseShowDto>> GetAll()
        {
            var expenseList = _expenseDal.GetExpenseForShow();
            return new SuccessDataResult<List<ExpenseShowDto>>(expenseList);
        }

        public IResult Update(ExpenseUpdateDto updatedExpense)
        {
            var mapExpense = _mapper.Map<Expense>(updatedExpense);
            _expenseDal.Update(mapExpense);
            return new SuccessResult(Messages.ExpenseUpdated);
        }
    }
}
