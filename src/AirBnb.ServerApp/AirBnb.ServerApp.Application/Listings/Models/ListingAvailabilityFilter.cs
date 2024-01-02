using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Entities;

namespace AirBnb.ServerApp.Application.Listings.Models;

/// <summary>
/// Represents listing availability filter
/// </summary>
public class ListingAvailabilityFilter : FilterPagination, IQueryConvertible<Listing>
{
    /// <summary>
    /// Gets the availability start date
    /// </summary>
    public DateOnly StartDate { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public QuerySpecification<Listing> ToQuerySpecification(bool asNoTracking = false)
    {
        return new QuerySpecification<Listing>(PageSize, PageToken, asNoTracking);
    }
    
    public override bool Equals(object? obj)
    {
        return obj is ListingAvailabilityFilter listingAvailabilityFilter && listingAvailabilityFilter.GetHashCode() == GetHashCode();
    }
    
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageSize);
        hashCode.Add(PageToken);
        hashCode.Add(StartDate);

        return hashCode.ToHashCode();
    }
}