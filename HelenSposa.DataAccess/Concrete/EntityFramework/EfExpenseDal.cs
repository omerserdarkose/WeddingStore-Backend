using HelenSposa.Core.DataAccess.EntityFramework;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.DataAccess.Concrete.EntityFramework
{
    public class EfExpenseDal : EfEntityRepositoryBase<Expense, HelenSposaDbContext>, IExpenseDal
    {
        public List<ExpenseShowDto> GetExpenseForShow()
        {
            using (var context = new HelenSposaDbContext())
            {
                var result = from exp in context.Expenses
                             join et in context.ExpenseTypes
                             on exp.TypeId equals et.Id
                             select new ExpenseShowDto 
                             {
                                 Id=exp.Id,
                                 TypeName=et.Name,
                                 Amount=exp.Amount,
                                 Date=exp.Date,
                                 Description=exp.Description
                             };
                return result.ToList();
            }
        }

    }
}
