using System.Linq.Expressions;
using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Persistence.Caching.Brokers;
using AirBnb.ServerApp.Persistence.Caching.Models;
using AirBnb.ServerApp.Persistence.DataContexts;
using AirBnb.ServerApp.Persistence.Repositories.Interfaces;

namespace AirBnb.ServerApp.Persistence.Repositories;

/// <summary>
/// Provides country repository functionalities
/// </summary>
public class CountryRepository(AppDbContext dbContext, ICacheBroker cacheBroker) : EntityRepositoryBase<Country, AppDbContext>(
    dbContext,
    cacheBroker,
    new CacheEntryOptions()
), ICountryRepository
{
    public new IQueryable<Country> Get(Expression<Func<Country, bool>>? predicate = null, bool asNoTracking = false) =>
        base.Get(predicate, asNoTracking);
}