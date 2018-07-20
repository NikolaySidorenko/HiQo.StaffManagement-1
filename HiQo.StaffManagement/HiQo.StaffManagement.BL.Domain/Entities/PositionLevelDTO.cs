using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Models
{
    public class PositionLevelDTO
    {
        public int PositionLevelId { get; set; }

        public string Name { get; set; }

        public int? Level { get; set; }

        public ICollection<UserDTO> Users { get; set; }

    }
}
