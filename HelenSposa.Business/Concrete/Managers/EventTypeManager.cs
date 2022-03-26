using AutoMapper;
using HelenSposa.Business.Abstract;
using HelenSposa.Business.Aspects.Autofac;
using HelenSposa.Business.Constant;
using HelenSposa.Business.ValidationRules.FluentValidation;
using HelenSposa.Core.Aspects.Autofac;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.EventType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace HelenSposa.Business.Concrete.Managers
{
    public class EventTypeManager : IEventTypeService
    {
        private IEventTypeDal _eventTypeDal;
        private IHttpContextAccessor _httpContextAccessor;
        private IMapper _mapper;

        public EventTypeManager(IEventTypeDal eventTypeDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _eventTypeDal = eventTypeDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        //[SecuredOperation("admin")]
        //[ValidationAspect(typeof(EventTypeAddValidator))]
        //[CacheRemoveAscpect("IEventTypeService.Get")]
        public IResult Add(EventTypeAddDto addedEventType)
        {
            var newEventType = _mapper.Map<EventType>(addedEventType);
            newEventType.Idate=DateTime.Now;
            newEventType.IuserId= _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            _eventTypeDal.Add(newEventType);
            newEventType.IsActive = true;
            return new SuccessResult(Messages.EventTypeAdded);
        }

        //[SecuredOperation("admin")]
        //[CacheRemoveAscpect("IEventTypeService.Get")]
        public IResult Delete(int id)
        {
            var delEventType = _eventTypeDal.Get(x => x.Id == id);
            if (delEventType is null)
            {
                return new ErrorResult(Messages.EventTypeNotFound);
            }
            delEventType.UuserId= _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            delEventType.Udate=DateTime.Now;
            delEventType.IsActive = false;
            _eventTypeDal.Update(delEventType);
            return new SuccessResult(Messages.EventTypeDeleted);
        }

        //[SecuredOperation("admin,worker")]
        //[CacheAspect(duration: 10)]
        public IDataResult<List<EventTypeShowDto>> GetAll()
        {
            var expenseTypeList = _eventTypeDal.GetList();
            var mapEventTypeList = _mapper.Map<List<EventTypeShowDto>>(expenseTypeList);
            return new SuccessDataResult<List<EventTypeShowDto>>(mapEventTypeList);
        }

        //[SecuredOperation("admin")]
        //[ValidationAspect(typeof(EventTypeUpdateValidator))]
        //[CacheRemoveAscpect("IEventTypeService.Get")]
        public IResult Update(int id,EventTypeUpdateDto updatedEventType)
        {
            var updEventType = _eventTypeDal.Get(x => x.Id == id);
            if (updEventType is null)
            {
                return new ErrorResult(Messages.EventTypeNotFound);
            }
            updEventType = _mapper.Map(updatedEventType,updEventType);
            updEventType.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            updEventType.Udate=DateTime.Now;
            _eventTypeDal.Update(updEventType);
            return new SuccessResult(Messages.EventTypeUpdated);
        }

        public bool IsExists(int id)
        {
            var result = _eventTypeDal.Any(x => x.Id == id);

            return result;
        }
    }
}
