using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Entities;

namespace AirBnb.ServerApp.Persistence.Repositories.Interfaces;

/// <summary>
/// Defines storage file repository functionalities
/// </summary>
public interface IListingCategoryRepository
{
    /// <summary>
    /// Retrieves a list of locations categories based on the specified query specification asynchronously.
    /// </summary>
    /// <param name="querySpecification">The query specification to apply.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Collection of matching locations categories.</returns>
    ValueTask<IList<ListingCategory>> GetAsync(QuerySpecification<ListingCategory> querySpecification, CancellationToken cancellationToken = default);

    object Get(bool asNoTracking);
}