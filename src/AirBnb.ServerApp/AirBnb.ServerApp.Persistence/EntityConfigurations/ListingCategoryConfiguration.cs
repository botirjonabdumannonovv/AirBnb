using AirBnb.ServerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBnb.ServerApp.Persistence.EntityConfigurations;

public class ListingCategoryConfiguration : IEntityTypeConfiguration<ListingCategory>
{
    public void Configure(EntityTypeBuilder<ListingCategory> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(64);

        builder.HasOne(listingCategory => listingCategory.ImageStorageFile).WithOne().HasForeignKey<ListingCategory>(storageFile => storageFile.Id);
    }
}