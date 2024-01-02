using AirBnb.ServerApp.Application.Common.Queries.Models;
using AirBnb.ServerApp.Application.Locations.Models;
using AirBnb.ServerApp.Application.Locations.Services;
using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Persistence.Extensions;
using AirBnb.ServerApp.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.ServerApp.Infrastructure.Locations.Services;

/// <summary>
/// Provides country foundation service functionality
/// </summary>
public class CountryService(ICountryRepository countryRepository) : ICountryService
{
    public async ValueTask<IList<Country>> GetAsync(
        CountryFilter filter,
        QueryOptions queryOptions = new(),
        CancellationToken cancellationToken = default
    )
    {
        var initialQuery = countryRepository.Get(asNoTracking: queryOptions.AsNoTracking);

        if (filter.IncludeCities)
            initialQuery.Include(country => country.Cities);

        if (filter.SearchKeyword is not null)
            initialQuery = initialQuery.Where(country => country.Name.ToLower().Contains(filter.SearchKeyword.ToLower()));

        initialQuery = initialQuery.ApplyPagination(filter);

        return await initialQuery.ToListAsync(cancellationToken: cancellationToken);
    }
}