using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.Entities;
using HelenSposa.Entities.Dtos.Claim;

namespace HelenSposa.Entities.Dtos.User
{
    public class UserUpdateDto:IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
