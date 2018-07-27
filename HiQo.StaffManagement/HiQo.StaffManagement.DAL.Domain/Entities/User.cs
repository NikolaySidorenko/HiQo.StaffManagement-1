using System;

namespace HiQo.StaffManagement.DAL.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string MainPhoneNumber { get; set; }

        public string Email { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        public int PositionLevelId { get; set; }
        public virtual PositionLevel PositionLevel { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}