using System.Linq.Expressions;
using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Persistence.DataContexts;
using AirBnb.ServerApp.Persistence.Repositories.Interfaces;

namespace AirBnb.ServerApp.Persistence.Repositories;

public class LocationRepository : EntityRepositoryBase<Location, AppDbContext>, ILocationRepository
{
    public LocationRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<Location?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<Location> CreateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(location, saveChanges, cancellationToken);
    }

    public ValueTask<Location> UpdateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(location, saveChanges, cancellationToken);
    }

    public ValueTask<Location?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }
}