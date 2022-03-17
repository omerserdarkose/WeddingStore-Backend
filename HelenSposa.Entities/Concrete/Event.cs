using System;
using System.Collections.Generic;
using HelenSposa.Core.Entities;

#nullable disable

namespace HelenSposa.Entities.Concrete
{
    public class Event : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TypeId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string No { get; set; }
        public bool IsActive { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }

    }
}
