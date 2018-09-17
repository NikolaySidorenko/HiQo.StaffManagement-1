using System;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
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
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ReverseMap();

            CreateMap<UpdateUserViewModel, UserDto>()
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
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src =>Convert.ToDouble(src.Latitude.Replace(".",","))))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src =>Convert.ToDouble(src.Longitude.Replace(".",","))))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ReverseMap();

            CreateMap<UserDto, UserBirthdayViewModel>();

            CreateMap<RegistrationUserViewModel,UserDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            CreateMap<LoginViewModel, UserDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));

            CreateMap<UserDto, MapViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<UserAuthDto, LoginViewModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));
        }
    }
}
