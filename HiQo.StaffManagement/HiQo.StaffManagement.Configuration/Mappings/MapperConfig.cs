using System;
using System.Linq;
using AutoMapper;

namespace HiQo.StaffManagement.Configuration.Mappings
{
    public class MapperConfig
    {
        public static void ConfigureAutomapper()
        {
            Mapper.Initialize(GetConfiguration);
        }

        private static void GetConfiguration(IMapperConfigurationExpression configuration)
        {
            var profiles = typeof(MapperConfig).Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));

            foreach (var profile in profiles)
            {
                configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
            }
        }
    }
}