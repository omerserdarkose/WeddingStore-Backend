using HelenSposa.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Entities.Dtos
{
    public class ExpenseTypeGeneralDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
