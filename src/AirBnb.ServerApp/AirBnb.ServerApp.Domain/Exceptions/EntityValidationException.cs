using System.ComponentModel.DataAnnotations;
using AirBnb.ServerApp.Domain.Common.Entities;
using AirBnb.ServerApp.Domain.Common.Exceptions;
using FluentValidation.Results;

namespace AirBnb.ServerApp.Domain.Exceptions;

/// <summary>
/// Represents entity conflict exception and stores error details
/// </summary>
public class EntityValidationException<TEntity>(
    Guid entityId,
    ICollection<ValidationFailure> errors,
    ExceptionVisibility visibility = ExceptionVisibility.Public
) : EntityExceptionBase(
    entityId,
    $"Entity {typeof(TEntity).Name} with id {entityId} has validation errors",
    new ValidationException(errors.ToString()),
    visibility
) where TEntity : IEntity
{
    public ICollection<ValidationFailure> Errors { get; set; } = errors;
}