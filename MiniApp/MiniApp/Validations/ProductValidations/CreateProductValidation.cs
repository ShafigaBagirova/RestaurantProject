using FluentValidation;
using MiniApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using MiniApp.Dtos.ProductDTOs;

namespace MiniApp.Validations.ProductValidations;

public class CreateProductValidation : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidation(RestaurantDbContext dbContext)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Product name is required.")
            .MaximumLength(100)
            .WithMessage("Product name must not exceed 100 characters.")
            .MustAsync(async (name, cancellation) =>
            {
                if (string.IsNullOrWhiteSpace(name))
                    return true;

                var exists = await dbContext.Product
                    .AnyAsync(p => p.Name.ToLower() == name.ToLower(), cancellation);
                return !exists;
            })
            .WithMessage("A product with this name already exists. Product names must be unique.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.")
            .LessThanOrEqualTo(999999999.99m)
            .WithMessage("Price must not exceed 999,999,999.99.");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));

        RuleFor(x => x.CategoryId)
            .GreaterThan(0)
            .WithMessage("Category ID must be greater than 0.")
            .MustAsync(async (categoryId, cancellation) =>
            {
                var exists = await dbContext.Category
                    .AnyAsync(c => c.Id == categoryId, cancellation);
                return exists;
            })
            .WithMessage("The specified category does not exist.");
    }
}

