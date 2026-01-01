using FluentValidation;
using MiniApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using MiniApp.Dtos.ProductDTOs;

namespace MiniApp.Validations.ProductValidations;

public class UpdateProductValidation : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductValidation(RestaurantDbContext dbContext)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product ID is required.")
            .MustAsync(async (id, cancellation) =>
                await dbContext.Product.AnyAsync(p => p.Id == id, cancellation))
            .WithMessage("Product with the specified ID does not exist.");

        RuleFor(x => x.Name)
            .MaximumLength(100)
            .WithMessage("Product name must not exceed 100 characters.")
            .CustomAsync(async (name, context, cancellation) =>
            {
                if (string.IsNullOrWhiteSpace(name))
                    return;

                var request = context.InstanceToValidate as UpdateProductRequest;
                if (request == null)
                    return;

                var exists = await dbContext.Product
                    .AnyAsync(p => p.Name.ToLower() == name.ToLower() && p.Id != request.Id, cancellation);
                
                if (exists)
                {
                    context.AddFailure("A product with this name already exists. Product names must be unique.");
                }
            })
            .When(x => !string.IsNullOrWhiteSpace(x.Name));

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.")
            .LessThanOrEqualTo(999999999.99m)
            .WithMessage("Price must not exceed 999,999,999.99.")
            .When(x => x.Price.HasValue);

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));

        RuleFor(x => x.CategoryId)
            .GreaterThan(0)
            .WithMessage("Category ID must be greater than 0.")
            .MustAsync(async (categoryId, cancellation) =>
            {
                if (!categoryId.HasValue)
                    return true;

                var exists = await dbContext.Category
                    .AnyAsync(c => c.Id == categoryId.Value, cancellation);
                return exists;
            })
            .WithMessage("The specified category does not exist.")
            .When(x => x.CategoryId.HasValue);
    }
}



