using AirBnb.ServerApp.Application.Listings.Models;
using AirBnb.ServerApp.Application.Listings.Services;

namespace AirBnb.ServerApp.Infrastructure.Listings.Services;

/// <summary>
/// Provides listing orchestration service functionalities.
/// </summary>
public class ListingOrchestrationService(IListingService listingService) : IListingOrchestrationService
{
    public async ValueTask<IList<ListingAnalysisDetails>> GetByAvailabilityAsync(
        ListingAvailabilityFilter listingAvailabilityFilter,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        var listingQuerySpecification = listingAvailabilityFilter.ToQuerySpecification(asNoTracking);
        var result = await listingService.GetAsync(listingQuerySpecification, cancellationToken);
        return result.Select(
                listing => new ListingAnalysisDetails
                {
                    Listing = listing
                }
            )
            .ToList();
    }
}