using System;

namespace HiQo.StaffManagement.BL.Domain.Entities
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string MainPhoneNumber { get; set; }

        public string Email { get; set; }

        public int DepartmentId { get; set; }
        public DepartmentDto Department { get; set; }

        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }

        public int PositionId { get; set; }
        public PositionDto Position { get; set; }

        public int PositionLevelId { get; set; }
        public PositionLevelDto PositionLevel { get; set; }

        public int RoleId { get; set; }
        public RoleDto Role { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }
    }
}