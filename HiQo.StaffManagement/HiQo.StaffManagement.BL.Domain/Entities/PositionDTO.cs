using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Models
{
    public class PositionDTO
    {
        public int PositionId { get; set; }

        public string Name { get; set; }

        public CategoryDTO Category { get; set; }

        public ICollection<UserDTO> Users { get; set; }
    }
}
