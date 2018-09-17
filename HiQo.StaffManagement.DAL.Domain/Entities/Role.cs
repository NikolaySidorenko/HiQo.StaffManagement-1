using System.Collections.Generic;

namespace HiQo.StaffManagement.DAL.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }

        public int RoleId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}