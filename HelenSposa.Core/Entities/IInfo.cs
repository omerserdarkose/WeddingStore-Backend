using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Entities
{
    public interface IInfo
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
