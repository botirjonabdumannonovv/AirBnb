namespace AirBnb.ServerApp.Application.Common.Queries.Models;

/// <summary>
/// Represents query options
/// </summary>
public readonly struct QueryOptions
{
    /// <summary>
    /// Determines whether to track query result or not
    /// </summary>
    public bool AsNoTracking { get; init; }
}