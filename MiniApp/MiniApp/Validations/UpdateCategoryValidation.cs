using FluentValidation;
using MiniApp.Data.Contexts;
using MiniApp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MiniApp.Validations;

public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryValidation(RestaurantDbContext dbContext)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Category ID is required.")
            .GreaterThan(0)
            .WithMessage("Category ID must be greater than 0.");

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

