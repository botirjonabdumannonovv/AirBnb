using AirBnb.ServerApp.Domain.Enums;

namespace AirBnb.ServerApp.Domain.Entities;

/// <summary>
/// Represents country as a location
/// </summary>
public class Country : Location
{
    public Country() => Type = LocationType.Country;
    
    /// <summary>
    /// Gets or sets location code
    /// </summary>
    public string Code { get; set; } = default!;

    /// <summary>
    /// Gets or sets related cities
    /// </summary>
    public IList<City> Cities { get; set; } = new List<City>();
}