using AutoMapper;

namespace HiQo.StaffManagement.WEB
{
    public class MapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles("HiQo.StaffManagement.Configuration"));
        }
    }
}