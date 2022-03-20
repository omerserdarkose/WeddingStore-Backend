using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.DataAccess;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Expense;

namespace HelenSposa.DataAccess.Abstract
{
    public interface IExpenseDal:IEntityRepository<Expense>
    {
        List<ExpenseShowDto> GetShowList(Expression<Func<ExpenseShowDto, bool>> filter = null);
    }
}
