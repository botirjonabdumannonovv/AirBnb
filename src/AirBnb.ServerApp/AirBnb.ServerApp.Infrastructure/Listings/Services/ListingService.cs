using AirBnb.ServerApp.Application.Listings.Services;
using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Persistence.Repositories.Interfaces;

namespace AirBnb.ServerApp.Infrastructure.Listings.Services;

/// <summary>
/// Provides location category foundation service functionality
/// </summary>
public class ListingService(IListingRepository listingRepository) : IListingService
{
    public ValueTask<IList<Listing>> GetAsync(QuerySpecification<Listing> querySpecification, CancellationToken cancellationToken = default)
    {
        return listingRepository.GetAsync(querySpecification, cancellationToken);
    }
}