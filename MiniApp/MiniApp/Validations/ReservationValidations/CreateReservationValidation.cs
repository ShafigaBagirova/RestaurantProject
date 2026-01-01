using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MiniApp.Data.Contexts;
using MiniApp.Dtos.ReservationDTOs;
using System;

namespace MiniApp.Validations.ReservationValidations;

public class CreateReservationValidation : AbstractValidator<CreateReservationRequest>
{

    public CreateReservationValidation(RestaurantDbContext dbcontext)
    {

        RuleFor(x => x.CustomerName)
            .NotEmpty().WithMessage("Customer name is required.")
            .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");

        RuleFor(x => x.CustomerPhone)
            .NotEmpty().WithMessage("Customer phone is required.")
            .MaximumLength(15).WithMessage("Customer phone cannot exceed 15 characters.")
            .MustAsync(async (phone, cancellation) =>
                !await dbcontext.Reservation.AnyAsync(r => r.CustomerPhone == phone, cancellation))
            .WithMessage("This phone number is already used for a reservation.");

        RuleFor(x => x.GuestCount)
            .GreaterThan(0).WithMessage("Guest count must be greater than 0.");

        RuleFor(x => x.ReservationDate)
            .NotEmpty().WithMessage("Reservation date is required.")
            .Must(date => date >= DateTime.Now).WithMessage("Reservation date must be in the future.");

        RuleFor(x => x.DiningTableId)
            .NotEmpty().WithMessage("Dining table is required" )
            .GreaterThan(0).WithMessage("DiningTableId must be greater than 0.");
    }
}

