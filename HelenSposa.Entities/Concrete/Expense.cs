using HelenSposa.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace HelenSposa.Entities.Concrete
{
    public partial class Expense : IEntity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public virtual ExpensesType Type { get; set; }
    }
}
