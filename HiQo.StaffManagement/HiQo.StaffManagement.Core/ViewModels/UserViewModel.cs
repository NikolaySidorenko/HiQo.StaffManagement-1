using System;

namespace HiQo.StaffManagement.Core.ViewModels
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string MainPhoneNumber { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Category { get; set; }
        public string Position { get; set; }
        public string PositionLevel { get; set; }
        public int Rating { get; set; }
        //Role?
    }
}
