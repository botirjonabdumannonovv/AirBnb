using AirBnb.Server.Api.Models.Dtos;
using AirBnb.ServerApp.Domain.Entities;
using AutoMapper;

namespace AirBnb.Server.Api.Mappers;

public class CityMapper : Profile
{
    public CityMapper()
    {
        CreateMap<City, CityDto>().ReverseMap();
    }
}