using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MiniApp.Data.Contexts;
using MiniApp.Dtos;

namespace MiniApp.Validations;

public class UpdateMenuValidation : AbstractValidator<UpdateMenuRequest>
{
    public UpdateMenuValidation(RestaurantDbContext dbContext)
    {
        RuleFor(x => x.CategoryIds)
            .NotEmpty()
            .WithMessage("Menu must have at least one category.")
            .MustAsync(async (categoryIds, cancellation) =>
            {
                if (categoryIds == null || categoryIds.Count == 0)
                    return true;

                var allExist = await dbContext.Category
                    .Where(c => categoryIds.Contains(c.Id))
                    .CountAsync(cancellation);

                return allExist == categoryIds.Count;
            })
            .WithMessage("Some of the selected categories do not exist.");

        RuleFor(x => x.RestaurantIds)
            .NotEmpty()
            .WithMessage("Menu must be assigned to at least one restaurant.")
            .MustAsync(async (restaurantIds, cancellation) =>
            {
                if (restaurantIds == null || restaurantIds.Count == 0)
                    return true;

                var allExist = await dbContext.Restaurant
                    .Where(r => restaurantIds.Contains(r.Id))
                    .CountAsync(cancellation);

                return allExist == restaurantIds.Count;
            })
            .WithMessage("Some of the selected restaurants do not exist.");
    }
}

