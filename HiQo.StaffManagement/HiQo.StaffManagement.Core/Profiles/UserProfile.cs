using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, UserViewModel>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.Name))
                .ForMember(dest => dest.PositionLevel, opt => opt.MapFrom(src => src.PositionLevel.Name))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToShortDateString()))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.PositionLevel.Level))
                .ReverseMap();
        }
    }
}
