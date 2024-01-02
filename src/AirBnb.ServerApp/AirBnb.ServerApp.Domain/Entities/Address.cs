namespace AirBnb.ServerApp.Domain.Entities;

/// <summary>
/// Represents an address.
/// </summary>
public class Address
{
    public string? City { get; set; } 
    
    /// <summary>
    /// Gets or sets the city Id
    /// </summary>
    public Guid? CityId { get; set; }

    /// <summary>
    /// Gets or sets the latitude value.
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Gets or sets the longitude value.
    /// </summary>
    public double Longitude { get; set; }
}