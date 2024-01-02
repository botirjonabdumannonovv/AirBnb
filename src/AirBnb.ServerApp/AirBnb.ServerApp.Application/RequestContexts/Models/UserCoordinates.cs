namespace AirBnb.ServerApp.Application.RequestContexts.Models;

/// <summary>
/// Represents coordinates
/// </summary>
public class UserCoordinates
{
    /// <summary>
    /// Gets or sets latitude
    /// </summary>
    public decimal? Latitude { get; set; }

    /// <summary>
    /// Gets or sets longitude
    /// </summary>
    public decimal? Longitude { get; set; }
}