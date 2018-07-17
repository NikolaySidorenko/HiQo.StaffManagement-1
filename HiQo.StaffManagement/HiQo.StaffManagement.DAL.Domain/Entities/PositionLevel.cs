using System.Collections.Generic;

namespace HiQo.StaffManagement.DAL.Domain.Entities
{
    public class PositionLevel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Level { get; set; }

        public virtual ICollection<User> Users { get; set; }

        //public PositionLevel()
        //{
        //    Users = new List<User>();
        //}
    }
}