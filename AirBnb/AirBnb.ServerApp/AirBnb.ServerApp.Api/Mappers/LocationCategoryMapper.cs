using AirBnb.Server.Api.Dtos;
using AirBnb.ServerApp.Domain.Entities;
using AutoMapper;

namespace AirBnb.Server.Api.Mappers;

public class LocationCategoryMapper : Profile
{
    public LocationCategoryMapper()
    {
        CreateMap<LocationCategoryDto, LocationCategory>().ReverseMap();
    }
}