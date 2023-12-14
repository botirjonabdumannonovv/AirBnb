using AirBnb.ServerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.ServerApp.Persistence.DataContexts;

public class AppDbContext : DbContext
{
    public DbSet<Location> Locations => Set<Location>();

    public DbSet<LocationCategory> LocationCategories => Set<LocationCategory>();

    public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}