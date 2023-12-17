namespace AirBnb.Server.Api.Dtos;

public class LocationCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;

    public string ImageUrl { get; set; } = default!;
}