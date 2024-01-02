using System.Linq.Expressions;
using AirBnb.ServerApp.Domain.Entities;

namespace AirBnb.ServerApp.Persistence.Repositories.Interfaces;

/// <summary>
/// Defines country repository functionalities
/// </summary>
public interface ICountryRepository
{
    /// <summary>
    /// Retrieves a list of countries based on predicate
    /// </summary>
    /// <param name="predicate">Predicate of query to be applied as filter</param>
    /// <param name="asNoTracking">Determines whether to track the query result or not </param>
    /// <returns>A list of countries that match the given predicate.</returns>
    IQueryable<Country> Get(Expression<Func<Country, bool>>? predicate = null, bool asNoTracking = false);
}