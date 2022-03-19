using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.Entities;

namespace HelenSposa.Entities.Dtos.User
{
    public class UserEmailDto:IDto
    {
        public string Email { get; set; }
    }
}
