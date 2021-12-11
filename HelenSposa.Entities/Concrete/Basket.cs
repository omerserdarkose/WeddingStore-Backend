using HelenSposa.Core.Entities;
using HelenSposa.Entities.Concrete;
using System;
using System.Collections.Generic;

#nullable disable

namespace HelenSposa.Entities.Concrete
{
    public class Basket:IEntity
    {
        public Basket()
        {
            BasketDetails = new HashSet<BasketDetail>();
            BasketsEvents = new HashSet<BasketsEvent>();
            Incomes = new HashSet<Income>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateOfSale { get; set; }
        public byte[] Photo { get; set; }
        public bool IsDone { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<BasketDetail> BasketDetails { get; set; }
        public virtual ICollection<BasketsEvent> BasketsEvents { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
    }
}