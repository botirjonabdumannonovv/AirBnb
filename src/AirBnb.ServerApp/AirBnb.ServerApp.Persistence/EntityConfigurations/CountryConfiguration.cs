using AirBnb.ServerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBnb.ServerApp.Persistence.EntityConfigurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(location => location.Code).IsRequired(false).HasMaxLength(64);
    }
}