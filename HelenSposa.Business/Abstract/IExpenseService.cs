using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.Entities.Dtos.Expense;

namespace HelenSposa.Business.Abstract
{
    public interface IExpenseService
    {
        IDataResult<List<ExpenseShowDto>> GetAll(Expression<Func<ExpenseShowDto, bool>> filter = null);
        IDataResult<List<ExpenseShowDto>> GetAllByTypeId(int typeId);
    }

}
