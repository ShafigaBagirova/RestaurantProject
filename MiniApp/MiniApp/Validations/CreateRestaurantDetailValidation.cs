using FluentValidation;
using MiniApp.Data.Entities;
using MiniApp.Dtos;

namespace MiniApp.Validations;

public class CreateRestaurantDetailValidation : AbstractValidator<CreateRestaurantDetailRequest>
{
    public CreateRestaurantDetailValidation()
    {
        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Address is required.")
            .MaximumLength(200)
            .WithMessage("Address must not exceed 200 characters.");


        RuleFor(x => x.Cuisine)
            .NotEmpty()
            .WithMessage("Cuisine type is required.")
            .MaximumLength(100)
            .WithMessage("Cuisine type must not exceed 100 characters.");

        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage("City is required.")
            .MaximumLength(100)
            .WithMessage("City name must be at least 2 characters long.")
            .Matches(@"^[a-zA-Z\s\-'\.]+$")
            .WithMessage("City name contains invalid characters. Only letters, spaces, hyphens, apostrophes, and periods are allowed.");

        RuleFor(x => x.RestaurantId)
            .GreaterThan(0)
            .WithMessage("Restaurant ID must be greater than 0.");
    }
}

