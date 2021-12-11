using HelenSposa.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace HelenSposa.Entities.Concrete
{
    public class Product : IEntity
    {
        public Product()
        {
            BasketDetails = new HashSet<BasketDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BasketDetail> BasketDetails { get; set; }
    }
}
