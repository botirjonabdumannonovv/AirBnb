using AirBnb.ServerApp.Persistence.Caching.Models;

namespace AirBnb.ServerApp.Persistence.Extensions;

/// <summary>
/// Provides caching extension functionalities
/// </summary>
public static class CachingExtensions
{
    /// <summary>
    /// Determines whether caching is enabled or not
    /// </summary>
    /// <param name="cacheEntryOptions">Cache entry options</param>
    /// <returns>True if enabled, otherwise false</returns>
    public static bool IsEnabled(this CacheEntryOptions? cacheEntryOptions) => cacheEntryOptions != null;
}