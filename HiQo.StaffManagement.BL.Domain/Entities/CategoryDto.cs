using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Entities
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public DepartmentDto Department { get; set; }

        public ICollection<PositionDto> CategoryPositions { get; set; }
        public ICollection<UserDto> Users { get; set; }
    }
}
