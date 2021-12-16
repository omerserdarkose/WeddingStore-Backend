using HelenSposa.Core.Utilities.Result;
using HelenSposa.Entities.Dtos.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Abstract
{
    public interface IExpenseService
    {
        IDataResult<List<ExpenseShowDto>> GetAll();
        IResult Add(ExpenseAddDto addedExpense);
        IResult Delete(ExpenseDeleteDto deletedExpense);
        IResult Update(ExpenseUpdateDto updatedExpense);
    }
}
