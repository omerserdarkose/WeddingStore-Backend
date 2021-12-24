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

        IDataResult<ExpenseShowDto> GetById(int id);

        IResult Add(ExpenseAddDto addedExpense);

        IResult Delete(int id);

        IResult Update(ExpenseUpdateDto updatedExpense);
    }
}
