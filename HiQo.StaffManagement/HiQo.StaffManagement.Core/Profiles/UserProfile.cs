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
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.CurrentDepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.CurrentCategoryId, opt => opt.MapFrom(src => src.Category.CategoryId))
                .ForMember(dest => dest.CurrentPositionId, opt => opt.MapFrom(src => src.Position.PositionId))
                .ForMember(dest => dest.CurrentPositionLevelId, opt => opt.MapFrom(src => src.PositionLevel.PositionLevelId))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date))
                .ForMember(dest => dest.CurrentRoleId, opt => opt.MapFrom(src => src.RoleId))
                .ReverseMap();

        }
    }
}
