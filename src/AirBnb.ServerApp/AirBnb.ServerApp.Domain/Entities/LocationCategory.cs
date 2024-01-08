using AirBnb.ServerApp.Domain.Common.Entities;

namespace AirBnb.ServerApp.Domain.Entities;

public class LocationCategory : Entity
{
    public string Name { get; set; } = default!;

    public string ImageUrl { get; set; } = default!;
}