using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.Entities;

namespace HelenSposa.Entities.Dtos.Event
{
    public class EventAddDto:IDto
    {
        public string Summary { get; set; }
        public int TypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }
}
