using System;
using System.Linq;
using AutoMapper;
using HiQo.StaffManagement.Core.Profiles;

namespace HiQo.StaffManagement.Configuration.Profiles
{
    public class MapperConfig
    {
        public static void ConfigureAutomapper()
        {
            Mapper.Initialize(GetConfiguration);
        }

        private static void GetConfiguration(IMapperConfigurationExpression configuration)
        {
            var profilesOfConfiguration = typeof(MapperConfig).Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));

            var profilesOfCore = typeof(Core.Profiles.UserProfile).Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));

            foreach (var profile in profilesOfConfiguration)
            {
                configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
            }

            foreach (var profile in profilesOfCore)
            {
                configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
            }

        }
    }
}