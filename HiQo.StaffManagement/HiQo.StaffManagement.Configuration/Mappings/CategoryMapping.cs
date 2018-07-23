using HiQo.StaffManagement.BL.Domain.Models;
using HiQo.StaffManagement.DAL.Domain.Entities;
using AutoMapper;

namespace HiQo.StaffManagement.Configuration.Mappings
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                .ReverseMap();
        }
    }
}
