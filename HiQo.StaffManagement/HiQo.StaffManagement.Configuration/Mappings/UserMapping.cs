using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Models;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.Configuration.Mappings
{
    public class UserMapping
    {
        public UserMapping()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
        }
    }
}
