using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MiniApp.Data.Contexts;
using MiniApp.Data.Entities;
using MiniApp.Dtos.ReservationDTOs;
using System;

namespace MiniApp.Validations.ReservationValidations;

public class UpdateReservationValidation : AbstractValidator<UpdateReservationRequest>
{

    public UpdateReservationValidation(RestaurantDbContext dbcontext)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Reservation Id is required")
            .MustAsync(async (id, cancellation) =>
                await dbcontext.Reservation.AnyAsync(r => r.Id == id, cancellation))
            .WithMessage("Reservation with the specified Id does not exist.");

        RuleFor(x => x.CustomerName)
            .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");

        RuleFor(x => x.CustomerPhone)
            .MaximumLength(15).WithMessage("Customer phone cannot exceed 15 characters.")
            .MustAsync(async (request, phone, cancellation) =>
                !await dbcontext.Reservation.AnyAsync(r => r.CustomerPhone == phone && r.Id != request.Id, cancellation))
            .WithMessage("This phone number is already used for another reservation.");

        RuleFor(x => x.GuestCount)
            .GreaterThan(0).WithMessage("Guest count must be greater than 0.");

        RuleFor(x => x.ReservationDate)
            .Must(date => date >=DateTime.Now).WithMessage("Reservation date must be in the future.");

        RuleFor(x => x.DiningTableId)
            .GreaterThan(0).WithMessage("DiningTableId must be greater than 0.");
    }
}

