using System;
using System.Collections.Generic;
using HelenSposa.Core.Entities;

#nullable disable

namespace HelenSposa.Entities.Concrete
{
    public class BasketDetail : IEntity
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public decimal Price { get; set; }
        public bool? SaleType { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }

    }
}
