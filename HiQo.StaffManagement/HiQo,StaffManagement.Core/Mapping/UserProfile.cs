using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo_StaffManagement.Core.ViewModels;

namespace HiQo_StaffManagement.Core.Mapping
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
                .ReverseMap();
        }
    }
}
