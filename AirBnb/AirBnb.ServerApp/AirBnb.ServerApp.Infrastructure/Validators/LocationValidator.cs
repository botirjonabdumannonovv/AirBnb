using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Domain.Enums;
using FluentValidation;

namespace AirBnb.ServerApp.Infrastructure.Validators;

public class LocationValidator : AbstractValidator<Location>
{
    public LocationValidator()
    {
        RuleSet(EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(location => location.ImageUrl).NotEmpty();
                RuleFor(location => location.Name).NotEmpty().MinimumLength(3).MaximumLength(255);
                RuleFor(location => location.BuiltYear).NotEmpty();
                RuleFor(location => location.PricePerNight).NotEmpty();
            });
        
        RuleSet(EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(location => location.ImageUrl).NotEmpty();
                RuleFor(location => location.Name).NotEmpty().MinimumLength(3).MaximumLength(255);
                RuleFor(location => location.BuiltYear).NotEmpty();
                RuleFor(location => location.PricePerNight).NotEmpty();
            });
    }
}