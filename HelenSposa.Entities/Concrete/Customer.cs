using System;
using System.Collections.Generic;
using HelenSposa.Core.Entities;

#nullable disable

namespace HelenSposa.Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public string IdentityNumber { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }
    }
}
