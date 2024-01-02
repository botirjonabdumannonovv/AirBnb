using AirBnb.Server.Api.Models.Dtos;
using AirBnb.ServerApp.Domain.Entities;
using AutoMapper;

namespace AirBnb.Server.Api.Mappers;

public class CountryMapper : Profile
{
    public CountryMapper()
    {
        CreateMap<Country, CountryDto>().ReverseMap();
    }
}