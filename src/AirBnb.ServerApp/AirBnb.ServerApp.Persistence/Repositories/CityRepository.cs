using System.Linq.Expressions;
using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Persistence.Caching.Brokers;
using AirBnb.ServerApp.Persistence.Caching.Models;
using AirBnb.ServerApp.Persistence.DataContexts;
using AirBnb.ServerApp.Persistence.Repositories.Interfaces;

namespace AirBnb.ServerApp.Persistence.Repositories;

/// <summary>
/// Provides city repository functionalities
/// </summary>
public class CityRepository(AppDbContext dbContext, ICacheBroker cacheBroker) : EntityRepositoryBase<City, AppDbContext>(
    dbContext,
    cacheBroker,
    new CacheEntryOptions()
), ICityRepository
{
    public new IQueryable<City> Get(Expression<Func<City, bool>>? predicate = default, bool asNoTracking = false) =>
        base.Get(predicate, asNoTracking);
}