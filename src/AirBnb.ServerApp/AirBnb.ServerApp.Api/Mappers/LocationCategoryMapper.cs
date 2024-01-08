using AirBnb.Server.Api.Dtos.Models;
using AirBnb.ServerApp.Domain.Entities;
using AutoMapper;

namespace AirBnb.Server.Api.Mappers;

public class LocationCategoryMapper : Profile
{
    public LocationCategoryMapper()
    {
        CreateMap<LocationCategory, LocationCategoryDto>().ReverseMap();
    }
}