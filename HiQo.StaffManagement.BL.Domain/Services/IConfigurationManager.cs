using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IConfigurationManager : IService
    {
        string GetAppSettings(string key);
    }
}
