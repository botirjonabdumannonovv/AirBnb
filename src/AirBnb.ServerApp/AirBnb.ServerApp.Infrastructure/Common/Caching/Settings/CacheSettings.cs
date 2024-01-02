namespace AirBnb.ServerApp.Infrastructure.Common.Caching.Settings;

/// <summary>
/// Represents cache settings
/// </summary>
public class CacheSettings
{
    /// <summary>
    /// Gets the absolute expiration in seconds
    /// </summary>
    public int AbsoluteExpirationInSeconds { get; init; }

    /// <summary>
    /// Gets the sliding expiration in seconds
    /// </summary>
    public int SlidingExpirationInSeconds { get; init; }
}