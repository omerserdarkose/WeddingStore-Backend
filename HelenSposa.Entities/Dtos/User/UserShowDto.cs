using HelenSposa.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Entities.Dtos.Claim;

namespace HelenSposa.Entities.Dtos.User
{
    public class UserShowDto:IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public List<ClaimShowDto> Claims { get; set; }
    }
}
