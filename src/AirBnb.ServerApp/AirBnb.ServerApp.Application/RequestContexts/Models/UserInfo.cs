namespace AirBnb.ServerApp.Application.RequestContexts.Models;

/// <summary>
/// Represents user info
/// </summary>
public class UserInfo
{
    /// <summary>
    /// Gets or sets user coordinates
    /// </summary>
    public UserCoordinates Coordinates { get; set; } = default!;

    /// <summary>
    /// Gets or sets user region
    /// </summary>
    public UserRegion Region { get; set; } = default!;
}