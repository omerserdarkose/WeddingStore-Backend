using HelenSposa.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace HelenSposa.Entities.Concrete
{
    public partial class BasketsEvent : IEntity
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int EventId { get; set; }

        public virtual Basket Basket { get; set; }
        public virtual Event Event { get; set; }
    }
}
