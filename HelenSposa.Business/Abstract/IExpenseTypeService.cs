using HelenSposa.Core.Utilities.Result;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Abstract
{
    public interface IExpenseTypeService
    {
        IDataResult<List<ExpenseTypeGeneralDto>> GetAll();
        IResult Add(ExpenseTypeGeneralDto addedExpenseType);
        IResult Delete(ExpenseTypeGeneralDto deletedExpenseType);
        IResult Update(ExpenseTypeGeneralDto updatedExpenseType);
    }
}
