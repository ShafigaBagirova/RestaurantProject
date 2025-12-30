using FluentValidation;
using MiniApp.Dtos;

namespace MiniApp.Validations;

public class UpdateRestaurantDetailRequestValidation : AbstractValidator<UpdateRestaurantDetailRequest>
{
    public UpdateRestaurantDetailRequestValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Restaurant detail ID is required.")
            .GreaterThan(0)
            .WithMessage("Restaurant detail ID is required and must be greater than 0.");

        RuleFor(x => x.Address)
            .MaximumLength(200)
            .WithMessage("Address must not exceed 200 characters.")
            .MinimumLength(5)
            .WithMessage("Address must be at least 5 characters long.")
            .When(x => !string.IsNullOrWhiteSpace(x.Address));

        RuleFor(x => x.Cuisine)
            .MaximumLength(100)
            .WithMessage("Cuisine type must not exceed 100 characters.")
            .MinimumLength(2)
            .WithMessage("Cuisine type must be at least 2 characters long.")
            .When(x => !string.IsNullOrWhiteSpace(x.Cuisine));

        RuleFor(x => x.City)
            .MaximumLength(100)
            .WithMessage("City name must not exceed 100 characters.")
            .MinimumLength(2)
            .WithMessage("City name must be at least 2 characters long.")
            .Matches(@"^[a-zA-Z\s\-'\.]+$")
            .WithMessage("City name contains invalid characters. Only letters, spaces, hyphens, apostrophes, and periods are allowed.")
            .When(x => !string.IsNullOrWhiteSpace(x.City));
    }
}

