using HelenSposa.Core.Entities;

namespace HelenSposa.Entities.Dtos.Product
{
    public class ProductUpdateDto : IDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
