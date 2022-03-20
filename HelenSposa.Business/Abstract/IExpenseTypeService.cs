using HelenSposa.Core.Utilities.Result;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.ExpenseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Abstract
{
    public interface IExpenseTypeService
    {
        IDataResult<List<ExpenseTypeShowDto>> GetAll();
        IResult Add(ExpenseTypeAddDto addedExpenseType);
        IResult Delete(int id);
        IResult Update(int id, ExpenseTypeUpdateDto updatedExpenseType);
        bool IsExists(int id);
    }
}
