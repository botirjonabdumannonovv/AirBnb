using AirBnb.ServerApp.Domain.Common.Entities;

namespace AirBnb.ServerApp.Domain.Entities;

public class Location : SoftDeletedEntity 
{
    public string? ImageUrl { get; set; }
    
    public string? Name { get; set; }
    
    public int? BuiltYear { get; set; }
    
    public int? PricePerNight { get; set; }
}