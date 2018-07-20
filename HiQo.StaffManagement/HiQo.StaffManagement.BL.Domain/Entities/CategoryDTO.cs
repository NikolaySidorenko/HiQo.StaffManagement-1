using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Models
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public DepartmentDTO Department { get; set; }

        public ICollection<PositionDTO> CategoryPositions { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}
