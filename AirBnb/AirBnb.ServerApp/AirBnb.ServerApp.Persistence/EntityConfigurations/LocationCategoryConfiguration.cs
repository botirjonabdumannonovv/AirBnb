using AirBnb.ServerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBnb.ServerApp.Persistence.EntityConfigurations;

public class LocationCategoryConfiguration : IEntityTypeConfiguration<LocationCategory>
{
    public void Configure(EntityTypeBuilder<LocationCategory> builder)
    {
        builder.Property(locationCategory => locationCategory.Name).HasMaxLength(255);
        builder.Property(locationCategory => locationCategory.ImageUrl).IsRequired();
    }
}