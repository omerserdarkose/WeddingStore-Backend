using HelenSposa.Core.Entities;

namespace HelenSposa.Entities.Dtos.ExpenseType
{
    public class ExpenseTypeShowDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
