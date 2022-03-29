using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.Entities.Dtos.Event;

namespace HelenSposa.Business.Abstract
{
    public interface IEventService
    {
        IResult Add(EventAddDto eventAddDto);
        IResult Update(int id, EventUpdateDto eventUpdateDto);
    }
}
