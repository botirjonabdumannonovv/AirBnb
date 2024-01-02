using AirBnb.ServerApp.Domain.Common.Exceptions;

namespace AirBnb.ServerApp.Domain.Exceptions;

/// <summary>
/// Represents entity exception
/// </summary>
public class EntityExceptionBase(
    Guid entityId,
    string? message = default,
    Exception? innerException = default,
    ExceptionVisibility visibility = ExceptionVisibility.Public
) : ExceptionBase(message, innerException, visibility)
{
    public Guid Id { get; set; } = entityId;
}