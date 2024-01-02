using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Persistence.Caching.Brokers;
using AirBnb.ServerApp.Persistence.Caching.Models;
using AirBnb.ServerApp.Persistence.DataContexts;
using AirBnb.ServerApp.Persistence.Repositories.Interfaces;

namespace AirBnb.ServerApp.Persistence.Repositories;

/// <summary>
/// Provides listing repository functionalities
/// </summary>
public class ListingRepository(AppDbContext dbContext, ICacheBroker cacheBroker) : EntityRepositoryBase<Listing, AppDbContext>(
    dbContext,
    cacheBroker,
    new CacheEntryOptions()
), IListingRepository
{
    public new ValueTask<IList<Listing>> GetAsync(QuerySpecification<Listing> querySpecification, CancellationToken cancellationToken = default)
    {
        return base.GetAsync(querySpecification, cancellationToken);
    }
}