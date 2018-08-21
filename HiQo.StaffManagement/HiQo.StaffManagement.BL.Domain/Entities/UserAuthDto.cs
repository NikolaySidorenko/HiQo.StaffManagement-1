using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiQo.StaffManagement.BL.Domain.Entities
{
    public class UserAuthDto
    {
        public string UserName { get; set; }

        public string PasswordHash { get; set; }
    }
}
