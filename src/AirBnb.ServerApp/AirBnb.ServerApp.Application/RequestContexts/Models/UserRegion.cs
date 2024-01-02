namespace AirBnb.ServerApp.Application.RequestContexts.Models;

/// <summary>
/// Represents user region 
/// </summary>
public class UserRegion
{
    /// <summary>
    /// Gets or sets city name
    /// </summary>
    public string? CityName { get; set; }

    /// <summary>
    /// Gets or sets country name
    /// </summary>
    public string? CountryName { get; set; }

    /// <summary>
    ///  Gets or sets language
    /// </summary>
    public string Language { get; set; } = default!;
}