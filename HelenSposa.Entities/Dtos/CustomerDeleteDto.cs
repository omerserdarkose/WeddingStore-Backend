using HelenSposa.Core.Entities;

namespace HelenSposa.Entities.Dtos
{
    public class CustomerDeleteDto:IDto,IInfo
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}