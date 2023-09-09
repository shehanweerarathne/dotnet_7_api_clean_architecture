using AutoMapper;
using MyApp.Domain.DTOs;
using MyApp.Domain.Entities;

namespace MyApp.Domain.Mappings;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<CategoryDto, Category>().ReverseMap();
    }
}