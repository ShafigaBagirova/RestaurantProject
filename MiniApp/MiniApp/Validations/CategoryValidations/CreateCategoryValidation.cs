using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MiniApp.Data.Entities;
using MiniApp.Data.Contexts;
using MiniApp.Dtos.CategoryDTOs;

namespace MiniApp.Validations.CategoryValidations;

public class CreateCategoryValidation : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidation(RestaurantDbContext dbContext)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Category name is required.")
            .MaximumLength(100)
            .WithMessage("Category name must not exceed 100 characters.")
            .MustAsync(async (name, cancellation) =>
            {
                if (string.IsNullOrWhiteSpace(name))
                    return true;

                var exists = await dbContext.Category
                    .AnyAsync(r => r.Name.ToLower() == name.ToLower(), cancellation);
                return !exists;
            })
            .WithMessage("A Category with this name already exists. Category names must be unique.");


        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));
    }
}

