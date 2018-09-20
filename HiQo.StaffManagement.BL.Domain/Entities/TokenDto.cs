namespace HiQo.StaffManagement.BL.Domain.Entities
{
    public class TokenDto
    {
        public int Id { get; set; }

        public string RefreshToken { get; set; }

        public int UserId { get; set; }

        public UserDto User { get; set; }
    }
}
