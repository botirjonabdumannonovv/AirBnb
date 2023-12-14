using AirBnb.ServerApp.Domain.Common.Entities;

namespace AirBnb.ServerApp.Domain.Entities;

public class LocationCategory : SoftDeletedEntity
{
    public string? Name { get; set; }
    
    public string? ImageUrl { get; set; }
}