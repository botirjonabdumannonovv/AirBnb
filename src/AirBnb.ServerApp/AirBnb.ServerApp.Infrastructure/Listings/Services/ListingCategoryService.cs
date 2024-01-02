using AirBnb.ServerApp.Application.Common.Queries.Models;
using AirBnb.ServerApp.Application.Listings.Models;
using AirBnb.ServerApp.Application.Listings.Services;
using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Persistence.Repositories.Interfaces;

namespace AirBnb.ServerApp.Infrastructure.Listings.Services;

/// <summary>
/// Provides location category foundation service functionality
/// </summary>
public class ListingCategoryService(IListingCategoryRepository listingCategoryRepository) : IListingCategoryService
{
    public async ValueTask<IList<ListingCategory>> GetAsync(
        ListingCategoryFilter listingCategoryFilter,
        QueryOptions queryOptions = new(),
        CancellationToken cancellationToken = default
    )
    {
        return await new ValueTask<IList<ListingCategory>>();
    }
}