using AirBnb.ServerApp.Domain.Common.Query;

namespace AirBnb.ServerApp.Application.Locations.Models;

/// <summary>
/// Represents a city filter
/// </summary>
public class CityFilter : FilterPagination
{
    /// <summary>
    /// Gets the search keyword for city filtering
    /// </summary>
    public string? SearchKeyword { get; init; }
}