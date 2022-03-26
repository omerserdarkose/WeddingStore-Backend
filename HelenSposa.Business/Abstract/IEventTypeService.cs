using HelenSposa.Core.Utilities.Result;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.ExpenseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Entities.Dtos.EventType;

namespace HelenSposa.Business.Abstract
{
    public interface IEventTypeService
    {
        IDataResult<List<EventTypeShowDto>> GetAll();
        IResult Add(EventTypeAddDto addedEventType);
        IResult Delete(int id);
        IResult Update(int id, EventTypeUpdateDto updatedEventType);
        bool IsExists(int id);
    }
}
