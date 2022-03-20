using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.DataAccess.EntityFramework;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.DataAccess.Context;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Expense;

namespace HelenSposa.DataAccess.Concrete.EntityFramework
{
    public class EfExpenseDal:EfEntityRepositoryBase<Expense,HelenSposaDbContext>,IExpenseDal
    {
        //genel listeyi gosteriminde kullaniliyor. tip bazinda listelerde repository methodunu kullan
        public List<ExpenseShowDto> GetShowList(Expression<Func<ExpenseShowDto, bool>> filter = null)
        {
            using (var context = new HelenSposaDbContext())
            {
                var result = from e in context.Expenses
                    join et in context.ExpenseTypes
                        on e.TypeId equals et.Id
                    select new ExpenseShowDto()
                    {
                        Id = e.Id,
                        TypeId = e.TypeId,
                        TypeName = et.Name,
                        Amount = e.Amount,
                        Date = e.Date,
                        Description = e.Description
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
