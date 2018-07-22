using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Models;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.Configuration.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.Name))
                .ForMember(dest => dest.PositionLevel, opt => opt.MapFrom(src => src.PositionLevel.Name))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.PositionLevel.Level))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));
                //.ReverseMap()?
        }
    }
}