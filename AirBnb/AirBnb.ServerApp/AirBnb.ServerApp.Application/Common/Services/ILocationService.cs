using System.Linq.Expressions;
using AirBnb.ServerApp.Domain.Entities;

namespace AirBnb.ServerApp.Application.Common.Services;

public interface ILocationService
{
    IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Location?> GetByIdAsync(Guid locationId, bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<Location> CreateAsync(Location location, bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<Location> UpdateAsync(Location location, bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<Location?> DeleteByIdAsync(Guid locationId, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}