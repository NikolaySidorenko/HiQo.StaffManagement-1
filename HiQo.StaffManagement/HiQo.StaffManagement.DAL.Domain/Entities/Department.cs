using System.Collections.Generic;

namespace HiQo.StaffManagement.DAL.Domain.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Category> CategoryNames { get; set; }

        public virtual ICollection<User> Users { get; set; }

        //public Department()
        //{
        //    CategoryNames = new List<Category>();
        //}
    }
}