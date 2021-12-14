using HelenSposa.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace HelenSposa.Entities.Concrete
{
    public partial class Event : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TypeId { get; set; }
        public DateTime Date { get; set; }
        public string No { get; set; }
        public bool IsDone { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual EventType Type { get; set; }
        public virtual BasketsEvent BasketsEvent { get; set; }
    }
}
