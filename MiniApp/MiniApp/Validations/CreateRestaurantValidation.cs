using FluentValidation;
using MiniApp.Data.Contexts;
using MiniApp.Data.Entities;
using MiniApp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MiniApp.Validations;

public class CreateRestaurantValidation : AbstractValidator<CreateRestaurantRequest>
{
    public CreateRestaurantValidation(RestaurantDbContext dbContext)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Restaurant name is required.")
            .MaximumLength(100)
            .WithMessage("Restaurant name must not exceed 100 characters.")
            .MustAsync(async (name, cancellation) =>
            {
                if (string.IsNullOrWhiteSpace(name))
                    return true;

                var exists = await dbContext.Restaurant
                    .AnyAsync(r => r.Name.ToLower() == name.ToLower(), cancellation);
                return !exists;
            })
            .WithMessage("A restaurant with this name already exists. Restaurant names must be unique.");
          
        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .MaximumLength(20)
            .WithMessage("Phone number must not exceed 20 characters.")
            .Matches(@"^[\d\s\-\+\(\)]+$")
            .WithMessage("Phone number contains invalid characters. Only digits, spaces, hyphens, plus signs, and parentheses are allowed.");
    }
}

