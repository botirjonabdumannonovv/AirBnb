using AirBnb.ServerApp.Domain.Common.Entities;
using AirBnb.ServerApp.Domain.Enums;

namespace AirBnb.ServerApp.Domain.Entities;

/// <summary>
/// Represents unit of location 
/// </summary>
public abstract class Location : Entity
{
    /// <summary>
    /// Gets or sets location name
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Gets or sets location type
    /// </summary>
    public LocationType Type { get; set; }
}