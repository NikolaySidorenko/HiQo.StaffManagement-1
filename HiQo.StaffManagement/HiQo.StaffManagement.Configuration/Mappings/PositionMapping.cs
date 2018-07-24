using HiQo.StaffManagement.DAL.Domain.Entities;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.Configuration.Mappings
{
    public class PositionMapping : Profile
    {
        public PositionMapping()
        {
            CreateMap<Position, PositionDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users)) 
                .ReverseMap();
        }
    }
}
