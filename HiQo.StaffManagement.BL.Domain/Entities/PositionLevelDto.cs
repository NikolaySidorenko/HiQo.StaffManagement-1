using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Entities
{
    public class PositionLevelDto
    {
        public int PositionLevelId { get; set; }

        public string Name { get; set; }

        public int? Level { get; set; }

        public IEnumerable<UserDto> Users { get; set; }
    }
}