using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Models;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.Configuration.Mappings
{
    public class DepartmentMapping : Profile
    {
        public DepartmentMapping()
        {
            CreateMap<Department, DepartmentDto>()
                .ReverseMap();
        }
    }
}