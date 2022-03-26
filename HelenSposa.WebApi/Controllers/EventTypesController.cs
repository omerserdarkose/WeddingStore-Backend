using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelenSposa.Business.Abstract;
using HelenSposa.Entities.Dtos.EventType;


namespace HelenSposa.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventTypesController : ControllerBase
    {
        private IEventTypeService _eventTypeManager ;

        public EventTypesController(IEventTypeService eventTypeManager)
        {
            _eventTypeManager = eventTypeManager;
        }

        // GET: <EventTypesController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _eventTypeManager.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        
        // POST <EventTypesController>
        [HttpPost]
        public IActionResult AddEventType([FromBody] EventTypeAddDto newEventType)
        {
            var result = _eventTypeManager.Add(newEventType);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<EventTypesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateEventType([FromBody] EventTypeUpdateDto updEventType, int id)
        {
            var result = _eventTypeManager.Update(id,updEventType);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<EventTypesController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEventType(int id)
        {
            var result = _eventTypeManager.Delete(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
