using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MiniApp.Data.Contexts;
using MiniApp.Dtos.DiningTableDTOs;
using System;

namespace MiniApp.Validations.DiningTableValidations;

public class CreateDiningTableValidation : AbstractValidator<CreateDiningTableRequest>
{

    public CreateDiningTableValidation(RestaurantDbContext dbcontext)
    {
        RuleFor(x => x.DiningTableNumber)
            .GreaterThan(0).WithMessage("Dining table number must be greater than 0.")
            .MustAsync(async (request, number, cancellation) =>
                !await dbcontext.DiningTable
                    .AnyAsync(dt => dt.DiningTableNumber == number && dt.RestaurantId == request.RestaurantId, cancellation))
            .WithMessage("This dining table number already exists for this restaurant.");

        RuleFor(x => x.Capacity)
            .GreaterThan(0).WithMessage("Capacity must be greater than 0.");

        RuleFor(x => x.RestaurantId)
            .NotEmpty().WithMessage("Restaurant Id is required")
            .GreaterThan(0).WithMessage("RestaurantId must be greater than 0.");
    }
}

