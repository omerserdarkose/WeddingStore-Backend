using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.Entities;

namespace HelenSposa.Entities.Dtos.Expense
{
    public class ExpenseAddDto:IDto
    {
        public int TypeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
