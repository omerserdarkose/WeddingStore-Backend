using HelenSposa.Core.Entities;

namespace HelenSposa.Entities.Dtos.ExpenseType
{
    public class ExpenseTypeUpdateDto : IDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
