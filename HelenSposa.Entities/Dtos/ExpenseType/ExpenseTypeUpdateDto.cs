using HelenSposa.Core.Entities;

namespace HelenSposa.Entities.Dtos.ExpenseType
{
    public class ExpenseTypeUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
