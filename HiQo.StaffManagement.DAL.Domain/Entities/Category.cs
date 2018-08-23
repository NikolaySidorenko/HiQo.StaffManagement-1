using System.Collections.Generic;

namespace HiQo.StaffManagement.DAL.Domain.Entities
{
    public class Category
    {
        //public Category()
        //{
        //    CategoryPositions = new List<Position>();
        //    Users = new List<User>();
        //}

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Position> CategoryPositions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}