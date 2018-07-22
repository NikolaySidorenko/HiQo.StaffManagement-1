using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Models
{
    public class PositionDto
    {
        public int PositionId { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public IEnumerable<UserDto> Users { get; set; }
    }
}
