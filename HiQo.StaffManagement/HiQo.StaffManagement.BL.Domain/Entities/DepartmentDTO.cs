using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Models
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryDTO> CategoryNames { get; set; }

        public ICollection<UserDTO> Users { get; set; }
    }
}