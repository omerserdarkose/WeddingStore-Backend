using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.DataAccess;
using HelenSposa.Entities.Concrete;

namespace HelenSposa.DataAccess.Abstract
{
    public interface IEventDal:IEntityRepository<Event>
    {
    }
}
