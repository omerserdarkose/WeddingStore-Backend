using HelenSposa.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace HelenSposa.Entities.Concrete
{
    public partial class ExpenseType : IEntity
    {
        public ExpenseType()
        {
            Expenses = new HashSet<Expense>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
