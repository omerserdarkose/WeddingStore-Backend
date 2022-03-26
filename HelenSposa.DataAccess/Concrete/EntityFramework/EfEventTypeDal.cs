using HelenSposa.Core.DataAccess;
using HelenSposa.Core.DataAccess.EntityFramework;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.DataAccess.Context;

namespace HelenSposa.DataAccess.Concrete.EntityFramework
{
    public class EfEventTypeDal:EfEntityRepositoryBase<EventType,HelenSposaDbContext>,IEventTypeDal
    {
    }
}
