using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Domain.Enums;
using FluentValidation;

namespace AirBnb.ServerApp.Infrastructure.Validators;

public class LocationCategoryValidator : AbstractValidator<LocationCategory>
{
    public LocationCategoryValidator()
    {
        RuleSet(EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(locationCategory => locationCategory.Name).NotEmpty().MinimumLength(3).MaximumLength(255);
                RuleFor(locationCategory => locationCategory.ImageUrl).NotEmpty();
            });
        
        RuleSet(EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(locationCategory => locationCategory.Name).NotEmpty().MinimumLength(3).MaximumLength(255);
                RuleFor(locationCategory => locationCategory.ImageUrl).NotEmpty();
            });
    }
}