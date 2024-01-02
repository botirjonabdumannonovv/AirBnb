using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBnb.ServerApp.Persistence.EntityConfigurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");

        builder.Property(location => location.Name).IsRequired().HasMaxLength(256);
        
        builder.HasDiscriminator(location => location.Type)
            .HasValue<City>(LocationType.City)
            .HasValue<Country>(LocationType.Country);
    }
}