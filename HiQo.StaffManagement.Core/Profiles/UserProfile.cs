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
                .ForMember(dest => dest.CurrentPositionLevelId,
                    opt => opt.MapFrom(src => src.PositionLevel.PositionLevelId))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.CurrentRoleId, opt => opt.MapFrom(src => src.RoleId));

            CreateMap<UserViewModel, UserDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.CurrentDepartmentId))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CurrentCategoryId))
                .ForMember(dest => dest.MainPhoneNumber, opt => opt.MapFrom(src => src.MainPhoneNumber))
                .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.CurrentPositionId))
                .ForMember(dest => dest.PositionLevelId, opt => opt.MapFrom(src => src.CurrentPositionLevelId))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.CurrentRoleId))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName));

            CreateMap<UserDto, UserBirthdayViewModel>();

            CreateMap<RegistrationUserViewModel,UserDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            CreateMap<RegistrationUserViewModel, UserViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<LoginViewModel, UserDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));

            
        }
    }
}
