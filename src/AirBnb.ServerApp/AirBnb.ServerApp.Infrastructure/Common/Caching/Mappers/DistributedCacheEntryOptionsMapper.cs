using AirBnb.ServerApp.Persistence.Caching.Models;
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;

namespace AirBnb.ServerApp.Infrastructure.Common.Caching.Mappers;

public class DistributedCacheEntryOptionsMapper : Profile
{
    public DistributedCacheEntryOptionsMapper()
    {
        CreateMap<CacheEntryOptions, DistributedCacheEntryOptions>();
    }
}