using FluentValidation;
using MiniApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using MiniApp.Dtos.CategoryDTOs;

namespace MiniApp.Validations.CategoryValidations;

public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryValidation(RestaurantDbContext dbContext)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Category ID is required.")
            .MustAsync(async (id, cancellation) =>
                await dbContext.Category.AnyAsync(c => c.Id == id, cancellation))
            .WithMessage("Category with the specified ID does not exist.");

        RuleFor(x => x.Name)
            .MaximumLength(100)
            .WithMessage("Category name must not exceed 100 characters.")
            .CustomAsync(async (name, context, cancellation) =>
            {
                if (string.IsNullOrWhiteSpace(name))
                    return;

                var request = context.InstanceToValidate as UpdateCategoryRequest;
                if (request == null)
                    return;

                var exists = await dbContext.Category
                    .AnyAsync(c => c.Name.ToLower() == name.ToLower() && c.Id != request.Id, cancellation);
                
                if (exists)
                {
                    context.AddFailure("A category with this name already exists. Category names must be unique.");
                }
            })
            .When(x => !string.IsNullOrWhiteSpace(x.Name));

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));
    }
}

