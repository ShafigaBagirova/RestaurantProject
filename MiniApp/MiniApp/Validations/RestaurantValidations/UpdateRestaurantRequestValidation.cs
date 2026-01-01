using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MiniApp.Data.Contexts;
using MiniApp.Dtos;
using MiniApp.Dtos.CategoryDTOs;
using MiniApp.Dtos.RestaurantDTOs;

namespace MiniApp.Validations.RestaurantValidations;

public class UpdateRestaurantRequestValidation : AbstractValidator<UpdateRestaurantRequest>
{
    public UpdateRestaurantRequestValidation(RestaurantDbContext dbContext)
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.")
               .MustAsync(async (id, cancellation) =>
                await dbContext.Restaurant.AnyAsync(s => s.Id == id, cancellation))
            .WithMessage("Restaurant with the specified Id does not exist.");

        RuleFor(x => x.Name)
            .MaximumLength(100).WithMessage("Restaurant name must not exceed 100 characters.")
              .CustomAsync(async (name, context, cancellation) =>
              {
                  if (string.IsNullOrWhiteSpace(name))
                      return;

                  var request = context.InstanceToValidate as UpdateRestaurantRequest;
                  if (request == null)
                      return;

                  var exists = await dbContext.Restaurant
                      .AnyAsync(c => c.Name.ToLower() == name.ToLower() && c.Id != request.Id, cancellation);

                  if (exists)
                  {
                      context.AddFailure("A Restaurant with this name already exists. Category names must be unique.");
                  }
              })
            .When(x => !string.IsNullOrWhiteSpace(x.Name));
        RuleFor(x => x.Address)
            .MaximumLength(200).WithMessage("Address must not exceed 200 characters.")
             .CustomAsync(async (address, context, cancellation) =>
             {
                 if (string.IsNullOrWhiteSpace(address))
                     return;

                 var request = context.InstanceToValidate as UpdateRestaurantRequest;
                 if (request == null)
                     return;

                 var exists = await dbContext.RestaurantDetail
                     .AnyAsync(c => c.Address.ToLower() == address.ToLower() && c.Id != request.Id, cancellation);

                 if (exists)
                 {
                     context.AddFailure("A Restaurant with this address already exists. A Restaurant's address must be unique.");
                 }
             })
            .When(x => !string.IsNullOrWhiteSpace(x.Address));

        RuleFor(x => x.City)
            .MaximumLength(100).WithMessage("A City Name must not exceed 200 characters.");

        RuleFor(x => x.Cuisine)
            .MaximumLength(100).WithMessage("Cuisine must not exceed 200 characters.");

        RuleFor(x => x.Phone)
            .MaximumLength(20).WithMessage("Cuisine must not exceed 200 characters.")
             .Matches(@"^[\d\s\-\+\(\)]+$")
                .WithMessage("Phone number contains invalid characters. Only digits, spaces, hyphens, plus signs, and parentheses are allowed.")
            .CustomAsync(async (phone, context, cancellation) =>
            {
                if (string.IsNullOrWhiteSpace(phone))
                    return;

                var request = context.InstanceToValidate as UpdateRestaurantRequest;
                if (request == null)
                    return;

                var exists = await dbContext.Restaurant
                    .AnyAsync(c => c.Phone.ToLower() == phone.ToLower() && c.Id != request.Id, cancellation);

                if (exists)
                {
                    context.AddFailure("A Restaurant with this phone already exists. Restaurant's phone must be unique.");
                }
            })
            .When(x => !string.IsNullOrWhiteSpace(x.Phone));

        RuleFor(x => x.MenuId)
            .GreaterThan(0).WithMessage("MenuId must be greater than 0.");
    }
}



