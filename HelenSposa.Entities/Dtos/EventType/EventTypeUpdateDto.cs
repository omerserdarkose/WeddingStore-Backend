using HelenSposa.Core.Entities;

namespace HelenSposa.Entities.Dtos.EventType
{
    public class EventTypeUpdateDto : IDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
