using HelenSposa.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace HelenSposa.Entities.Concrete
{
    public partial class ExpensesType : IEntity
    {
        public ExpensesType()
        {
            Expenses = new HashSet<Expense>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
