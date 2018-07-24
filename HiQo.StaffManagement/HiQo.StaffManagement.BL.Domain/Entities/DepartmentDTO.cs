using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Entities
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public IEnumerable<CategoryDto> CategoryNames { get; set; }

        public IEnumerable<UserDto> Users { get; set; }
    }
}