using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.Configuration.Profiles
{
    public class TokenProfile : Profile
    {
        public TokenProfile()
        {
            CreateMap<Token, TokenDto>()
                .ForMember(dto => dto.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
        }
    }
}
