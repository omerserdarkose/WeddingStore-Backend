using System;
using System.Collections.Generic;
using HelenSposa.Core.Entities;

#nullable disable

namespace HelenSposa.Entities.Concrete
{
    public class BasketsEvent : IEntity
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int EventId { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }

    }
}
