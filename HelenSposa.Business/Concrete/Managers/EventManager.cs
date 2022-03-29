using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HelenSposa.Business.Abstract;
using HelenSposa.Business.Constant;
using HelenSposa.Core.Extensions;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Event;
using Microsoft.AspNetCore.Http;

namespace HelenSposa.Business.Concrete.Managers
{
    public class EventManager:IEventService
    {
        private IEventDal _eventDal;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;

        public EventManager(IEventDal eventDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _eventDal = eventDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IResult Add(EventAddDto eventAddDto)
        {
            var newEvent = _mapper.Map<Event>(eventAddDto);

            newEvent.IuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            newEvent.Idate = DateTime.Now;
            newEvent.IsActive = true;

            _eventDal.Add(newEvent);

            return new SuccessResult(Messages.EventAdded);
        }

        public IResult Update(int id, EventUpdateDto eventUpdateDto)
        {
            var updEvent = _eventDal.Get(x => x.Id == id);

            if (updEvent is null)
            {
                return new ErrorResult(Messages.ExpenseNotExists);
            }

            updEvent = _mapper.Map(eventUpdateDto, updEvent);
            updEvent.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            updEvent.Udate = DateTime.Now;

            _eventDal.Update(updEvent);

            return new SuccessResult(Messages.ExpenseUpdated);
        }
    }
}
