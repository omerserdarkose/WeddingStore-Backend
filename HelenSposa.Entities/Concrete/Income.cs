using HelenSposa.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace HelenSposa.Entities.Concrete
{
    public class Income : IEntity
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public virtual Basket Basket { get; set; }
    }
}
