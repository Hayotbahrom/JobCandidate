using AutoMapper;
using JobCandidate.Domain.Entities;
using JobCandidate.Service.DTOs;

namespace JobCandidate.Service.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
