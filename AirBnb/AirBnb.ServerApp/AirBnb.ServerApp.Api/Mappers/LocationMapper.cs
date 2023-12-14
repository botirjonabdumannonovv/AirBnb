using AirBnb.Server.Api.Dtos;
using AutoMapper;

namespace AirBnb.Server.Api.Mappers;

public class LocationMapper : Profile
{
    public LocationMapper()
    {
        CreateMap<LocationDto, Location>().ReverseMap();
    }   
}