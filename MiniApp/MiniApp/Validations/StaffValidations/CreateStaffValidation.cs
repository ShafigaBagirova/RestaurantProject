using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MiniApp.Data.Contexts;
using MiniApp.Dtos.StaffDTOs;
using System;

namespace MiniApp.Validations.StaffValidations;

public class CreateStaffValidation : AbstractValidator<CreateStaffRequest>
{

    public CreateStaffValidation(RestaurantDbContext dbcontext)
    {

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters.");

        RuleFor(x => x.Position)
            .NotEmpty().WithMessage("Position is required.")
            .MaximumLength(50).WithMessage("Position cannot exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MustAsync(async (email, cancellation) =>
                !await dbcontext.Staffs.AnyAsync(s => s.Email == email, cancellation))
            .WithMessage("This email is already in use.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .MaximumLength(15).WithMessage("Phone number cannot exceed 15 characters.")
            .MustAsync(async (phone, cancellation) =>
                !await dbcontext.Staffs.AnyAsync(s => s.Phone == phone, cancellation))
            .WithMessage("This phone number is already in use.");

        RuleFor(x => x.Age)
            .GreaterThanOrEqualTo(18).WithMessage("Staff must be at least 18 years old.");

    }
}
