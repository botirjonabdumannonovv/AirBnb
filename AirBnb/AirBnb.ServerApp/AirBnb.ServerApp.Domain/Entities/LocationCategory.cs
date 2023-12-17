using AirBnb.ServerApp.Domain.Common.Entities;

namespace AirBnb.ServerApp.Domain.Entities;

public class LocationCategory : SoftDeletedEntity
{
    public string Name { get; init; } = default!;

    public string ImageUrl { get; init; } = default!;

    public virtual List<Location> Locations { get; } = new();
}