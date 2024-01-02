using AirBnb.ServerApp.Application.Listings.Models;

namespace AirBnb.ServerApp.Application.Listings.Services;

/// <summary>
/// Defines listing orchestration service functionalities.
/// </summary>
public interface IListingOrchestrationService
{
    /// <summary>
    /// Retrieves a list of listings and availability details based on the provided query specification.
    /// </summary>
    /// <param name="listingAvailabilityFilter">Filter being used to query</param>
    /// <param name="asNoTracking">Determines whether query result should be tracked or not, true to track</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Collection of matching listings including availability data.</returns>
    ValueTask<IList<ListingAnalysisDetails>> GetByAvailabilityAsync(
        ListingAvailabilityFilter listingAvailabilityFilter,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );
}