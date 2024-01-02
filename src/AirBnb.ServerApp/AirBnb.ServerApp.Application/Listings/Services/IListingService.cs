using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Entities;

namespace AirBnb.ServerApp.Application.Listings.Services;

/// <summary>
/// Defines listing foundation service functionalities.
/// </summary>
public interface IListingService
{
    /// <summary>
    /// Retrieves a list of listings based on the provided query specification.
    /// </summary>
    /// <param name="querySpecification">The query specification to apply.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Collection of matching listings.</returns>
    ValueTask<IList<Listing>> GetAsync(QuerySpecification<Listing> querySpecification, CancellationToken cancellationToken = default);
}