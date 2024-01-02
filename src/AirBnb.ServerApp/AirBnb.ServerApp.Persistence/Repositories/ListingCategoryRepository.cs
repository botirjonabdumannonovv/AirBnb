using System.Linq.Expressions;
using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Persistence.Caching.Brokers;
using AirBnb.ServerApp.Persistence.Caching.Models;
using AirBnb.ServerApp.Persistence.DataContexts;
using AirBnb.ServerApp.Persistence.Repositories.Interfaces;

namespace AirBnb.ServerApp.Persistence.Repositories;

/// <summary>
/// Provides listing category repository functionalities.
/// </summary>
public class ListingCategoryRepository(AppDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<ListingCategory, AppDbContext>(dbContext, cacheBroker, new CacheEntryOptions()), IListingCategoryRepository
{
    private IListingCategoryRepository _listingCategoryRepositoryImplementation;

    public new IQueryable<ListingCategory> Get(Expression<Func<ListingCategory, bool>>? predicate = null, bool asNoTracking = false) =>
        base.Get(predicate, asNoTracking);

    public ValueTask<IList<ListingCategory>> GetAsync(QuerySpecification<ListingCategory> querySpecification, CancellationToken cancellationToken = default)
    {
        return _listingCategoryRepositoryImplementation.GetAsync(querySpecification, cancellationToken);
    }

    public object Get(bool asNoTracking)
    {
        throw new NotImplementedException();
    }
}