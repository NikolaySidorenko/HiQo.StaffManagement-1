using System;

namespace HiQo.StaffManagement.BL.Domain.Models
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string MainPhoneNumber { get; set; }

        public string SecondPhoneNumber { get; set; }

        public string Email { get; set; }

        public DepartmentDTO Department { get; set; }

        public CategoryDTO Category { get; set; }

        public PositionDTO Position { get; set; }

        public PositionLevelDTO PositionLevel { get; set; }

        public RoleDTO Role { get; set; }
    }
}
