using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MiniApp.Data.Contexts;
using MiniApp.Data.Entities;
using MiniApp.Dtos;
using MiniApp.Dtos.RestaurantDTOs;

namespace MiniApp.Validations.RestaurantValidations;

public class CreateRestaurantValidation : AbstractValidator<CreateRestaurantRequest>
{
    public CreateRestaurantValidation(RestaurantDbContext dbContext)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Restaurant name must not exceed 100 characters.")
            .MaximumLength(100).WithMessage("Restaurant adı maksimum 100 simvol ola bilər.")
             .MustAsync(async (name, cancellation) =>
             {
                 if (string.IsNullOrWhiteSpace(name))
                     return true;

                 var exists = await dbContext.Restaurant
                     .AnyAsync(r => r.Name.ToLower() == name.ToLower(), cancellation);
                 return !exists;
             })
            .WithMessage("A restaurant with this name already exists. Restaurant names must be unique.");
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address cannot be empty.")
            .MaximumLength(200).WithMessage("Address must not exceed 200 characters.")
            .MustAsync(async (name, cancellation) =>
            {
                if (string.IsNullOrWhiteSpace(name))
                    return true;

                var exists = await dbContext.RestaurantDetail
                    .AnyAsync(r => r.Address.ToLower() == name.ToLower(), cancellation);
                return !exists;
            })
            .WithMessage("A restaurant  with this address already exists. Restaurant's address must be unique.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City cannot be empty.")
            .MaximumLength(100).WithMessage("City Name must not exceed 200 characters.");

        RuleFor(x => x.Cuisine)
            .NotEmpty().WithMessage("Cuisine cannot be empty.")
            .MaximumLength(100).WithMessage("Cuisine must not exceed 200 characters.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone cannot be empty.")
            .MaximumLength(20).WithMessage("Phone must not exceed 20 characters.")
             .Matches(@"^[\d\s\-\+\(\)]+$")
                .WithMessage("Phone number contains invalid characters. Only digits, spaces, hyphens, plus signs, and parentheses are allowed.")
            .MustAsync(async (phone, cancellation) =>
                !await dbContext.Restaurant.AnyAsync(r => r.Phone == phone, cancellation))
            .WithMessage("A restaurant with this phone already exists. Restaurant's phone must be unique.");

        RuleFor(x => x.MenuId)
            .GreaterThan(0).WithMessage("MenuId must be greater than 0.");
    }
}

