using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Models
{
    public class RoleDTO
    {
        public int RoleId { get; set; }

        public string Name { get; set; }

        public ICollection<UserDTO> Users { get; set; }
    }
}
