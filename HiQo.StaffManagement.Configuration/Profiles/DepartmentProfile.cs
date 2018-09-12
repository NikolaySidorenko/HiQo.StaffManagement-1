using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.Configuration.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.CategoryNames))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ReverseMap();
        }
    }
}