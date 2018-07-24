﻿using HiQo.StaffManagement.DAL.Domain.Entities;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.Configuration.Mappings
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ReverseMap();
        }
    }
}
