using HelenSposa.Core.Entities;

namespace HelenSposa.Entities.Dtos.Product
{
    public class ProductShowDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
