using System.Configuration;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.BL.Services
{
    public class ConfigurationManagerService : IConfigurationManager
    {
        public string GetAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}