using System;
using System.Collections.Generic;
using HelenSposa.Core.Entities;

#nullable disable

namespace HelenSposa.Core.Entities.Concrete
{
    public class Claim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }

    }
}
