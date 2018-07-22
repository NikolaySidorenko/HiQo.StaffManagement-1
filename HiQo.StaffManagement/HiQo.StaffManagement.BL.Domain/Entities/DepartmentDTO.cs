using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Models
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public IEnumerable<CategoryDTO> CategoryNames { get; set; }

        public IEnumerable<UserDto> Users { get; set; }
    }
}