using AirBnb.ServerApp.Application.Common.Queries.Models;
using AirBnb.ServerApp.Application.Listings.Models;
using AirBnb.ServerApp.Domain.Entities;

namespace AirBnb.ServerApp.Application.Listings.Services;

/// <summary>
/// Defines location category foundation service functionalities.
/// </summary>
public interface IListingCategoryService
{
    /// <summary>
    /// Retrieves a list of locations categories based on the provided query specification.
    /// </summary>
    /// <param name="listingCategoryFilter">The filter to apply.</param>
    /// <param name="queryOptions">Query options</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Collection of matching listing categories.</returns>
    ValueTask<IList<ListingCategory>> GetAsync(
        ListingCategoryFilter listingCategoryFilter,
        QueryOptions queryOptions = new(),
        CancellationToken cancellationToken = default
    );
}