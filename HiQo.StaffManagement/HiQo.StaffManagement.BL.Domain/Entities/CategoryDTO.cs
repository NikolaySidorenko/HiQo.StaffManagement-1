using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Models
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        //public ICollection<PositionDto> CategoryPositions { get; set; }
        //public ICollection<UserDto> Users { get; set; }
    }
}
