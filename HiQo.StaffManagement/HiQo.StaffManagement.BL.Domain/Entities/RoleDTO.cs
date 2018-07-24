using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Entities
{ 
    public class RoleDto
    {
        public int RoleId { get; set; }

        public string Name { get; set; }

        public IEnumerable<UserDto> Users { get; set; }
    }
}
