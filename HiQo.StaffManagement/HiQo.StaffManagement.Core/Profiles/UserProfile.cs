using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, UserIdViewModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Department.DepartmentId))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.CategoryId))
                .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.Position.PositionId))
                .ForMember(dest => dest.PositionLeveId, opt => opt.MapFrom(src => src.PositionLevel.PositionLevelId))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ReverseMap();

            CreateMap<UserDto, UserInformationViewModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.Name))
                .ForMember(dest => dest.PositionLeve, opt => opt.MapFrom(src => src.PositionLevel.Name))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date))
                .ReverseMap();
        }
    }
}
