using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Entities
{
    public class PositionDto
    {
        public int PositionId { get; set; }

        public string Name { get; set; }

        public CategoryDto Category { get; set; }

        public IEnumerable<UserDto> Users { get; set; }
    }
}
