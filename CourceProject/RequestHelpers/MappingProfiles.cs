using AutoMapper;
using CourceProject.DTOs;
using CourceProject.Entities;
using CourceProject.Models;

namespace CourceProject.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCarDto, Car>().ForMember
        (d => d.Manufacturer,
            opt => opt.MapFrom(src => src.Manufacturer.ToUpper()));
        CreateMap<UpdateCarDto, Car>().ForMember
        (d => d.Manufacturer,
            opt => opt.MapFrom(src => src.Manufacturer.ToUpper()));
        CreateMap<CommentDto, Comment>()
            .ForMember(d => d.Id,
                o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Body,
                o => o.MapFrom(s => s.Body))
            .ForMember(d => d.CreatedAt,
                o => o.MapFrom(s => s.CreatedAt));
        ;
    }
}