using HelenSposa.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace HelenSposa.Entities.Concrete
{
    public partial class Customer : IEntity, IInfo
    {
        public Customer()
        {
            Baskets = new HashSet<Basket>();
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
