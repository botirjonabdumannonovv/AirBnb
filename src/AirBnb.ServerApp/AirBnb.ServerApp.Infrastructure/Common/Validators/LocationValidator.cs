using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Domain.Enums;
using FluentValidation;

namespace AirBnb.ServerApp.Infrastructure.Common.Validators;

public class LocationValidator : AbstractValidator<Location>
{
    public LocationValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(location => location.Name).NotEmpty().MinimumLength(3).MaximumLength(64);
                RuleFor(location => location.BuiltYear).LessThan(DateTime.Now.Year).NotEmpty();
                RuleFor(location => location.ImageUrl).NotEmpty().NotNull();
                RuleFor(location => location.PricePerNight).NotEmpty().NotNull();
            }
        );
        
        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(location => location.Name).NotEmpty().MinimumLength(3).MaximumLength(64);
                RuleFor(location => location.BuiltYear).LessThan(DateTime.Now.Year).NotEmpty();
                RuleFor(location => location.ImageUrl).NotEmpty().NotNull();
                RuleFor(location => location.PricePerNight).NotEmpty().NotNull();
            }
        );
    }
}