using HelenSposa.Core.Entities;

namespace HelenSposa.Entities.Dtos.EventType
{
    public class EventTypeShowDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
