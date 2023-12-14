using System.Linq.Expressions;
using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Entities;

namespace AirBnb.ServerApp.Application.Common.Services;

public interface ILocationCategoryService
{
    IQueryable<LocationCategory> Get(Expression<Func<LocationCategory, bool>>? predicate = default,
        bool asNoTracking = false);

    ValueTask<IList<LocationCategory>> GetAsync(QuerySpecification<LocationCategory> querySpecification,
        bool asNoTracking = false, CancellationToken cancellationToken = default);
    
    ValueTask<LocationCategory?> GetByIdAsync(Guid locationCategoryId, bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<LocationCategory> CreateAsync(LocationCategory locationCategory, bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<LocationCategory> UpdateAsync(LocationCategory locationCategory, bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<LocationCategory?> DeleteByIdAsync(Guid locationCategoryId, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}