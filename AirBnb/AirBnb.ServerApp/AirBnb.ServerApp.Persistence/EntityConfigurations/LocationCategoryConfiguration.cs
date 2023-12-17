using AirBnb.ServerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBnb.ServerApp.Persistence.EntityConfigurations;

public class LocationCategoryConfiguration : IEntityTypeConfiguration<LocationCategory>
{
    public void Configure(EntityTypeBuilder<LocationCategory> builder)
    {
        builder.Property(template => template.Name).IsRequired().HasMaxLength(256);
        builder.Property(template => template.ImageUrl).IsRequired().HasMaxLength(256);

        builder
            .HasMany(category => category.Locations)
            .WithOne(location => location.Category);
    }
}