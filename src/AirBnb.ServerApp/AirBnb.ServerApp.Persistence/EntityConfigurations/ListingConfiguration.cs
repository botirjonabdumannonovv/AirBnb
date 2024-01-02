using AirBnb.ServerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBnb.ServerApp.Persistence.EntityConfigurations;

public class ListingConfiguration : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        builder.Property(listing => listing.Name).IsRequired().HasMaxLength(255);
        
        builder.HasOne(listing => listing.Category).WithMany().HasForeignKey(listing => listing.CategoryId);

        builder.OwnsOne(listing => listing.Address).Property(address => address.City).IsRequired(false).HasMaxLength(256);
        builder.OwnsOne(listing => listing.PricePerNight);
    }
}