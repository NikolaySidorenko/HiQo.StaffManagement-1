using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.Configuration.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ForMember(dest => dest.PositionLevel, opt => opt.MapFrom(src => src.PositionLevel))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(dest => dest.Latitude))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dto => dto.SecurityStamp, opt => opt.MapFrom(src => src.SecurityStamp))
                .ReverseMap();
        }
    }
}