using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Entities;

namespace AirBnb.ServerApp.Persistence.Repositories.Interfaces;

/// <summary>
/// Defines listing repository functionalities
/// </summary>
public interface IListingRepository
{
    /// <summary>
    /// Retrieves a list of listings based on the specified query specification asynchronously.
    /// </summary>
    /// <param name="querySpecification">The query specification to apply.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Collection of matching listings.</returns>
    ValueTask<IList<Listing>> GetAsync(QuerySpecification<Listing> querySpecification, CancellationToken cancellationToken = default);
}