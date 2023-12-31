﻿using AirBnb.Server.Api.Dtos.Models;
using AirBnb.ServerApp.Domain.Entities;
using AutoMapper;

namespace AirBnb.Server.Api.Mappers;

public class LocationMapper : Profile
{
    public LocationMapper()
    {
        CreateMap<LocationDto, Location>().ReverseMap();
    }
}