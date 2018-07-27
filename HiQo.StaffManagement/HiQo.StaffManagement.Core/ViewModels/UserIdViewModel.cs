using System;

namespace HiQo.StaffManagement.Core.ViewModels
{
    public class UserIdViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string MainPhoneNumber { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; } // TODO:Dictionary(id,Name) CurrentIdDepa
        public int CategoryId { get; set; }
        public int PositionId { get; set; }
        public int PositionLeveId { get; set; }
        public int RoleId { get; set; }
    }
}
