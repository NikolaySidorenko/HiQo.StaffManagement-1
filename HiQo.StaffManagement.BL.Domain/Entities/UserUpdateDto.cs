using System;

namespace HiQo.StaffManagement.BL.Domain.Entities
{
    public class UserUpdateDto
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string MainPhoneNumber { get; set; }

        public string Email { get; set; }

        public int? DepartmentId { get; set; } = null;
        public DepartmentDto Department { get; set; }

        public int? CategoryId { get; set; } = null;
        public CategoryDto Category { get; set; }

        public int? PositionId { get; set; } = null;
        public PositionDto Position { get; set; }

        public int? PositionLevelId { get; set; } = null;
        public PositionLevelDto PositionLevel { get; set; }

        public int? RoleId { get; set; } = 1;
        public RoleDto Role { get; set; }

        public double? Latitude { get; set; } = null;

        public double? Longitude { get; set; } = null;

        public string Address { get; set; }
    }
}
