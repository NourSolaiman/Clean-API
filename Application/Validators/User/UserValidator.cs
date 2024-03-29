﻿using Domain.Models;
using FluentValidation;

namespace Application;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Id)
            .NotEmpty().WithMessage("User Id cannot be empty");

        RuleFor(user => user.Username)
            .NotEmpty().WithMessage("Username cannot be empty")
            .MaximumLength(10).WithMessage("Username cant be longer than 10 letters")
            .MinimumLength(5).WithMessage("Username minimum lenth 5 letters")
            .Matches("^[a-zA-Z0-9_-]+$").WithMessage("Username can only contain letters, numbers, underscores, and hyphens.");

        RuleFor(user => user.PasswordHash)
            .NotEmpty().WithMessage("PasswordHash can not be empty")
            .MinimumLength(5).WithMessage("Minimum password length is 5 letters long")
            .MaximumLength(15).WithMessage("Maximum password length is 15 letters")
            .Matches("[A-Z]").WithMessage("PasswordHash must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("PasswordHash must contain at least one lowercase letter")
            .Matches("[^a-zA-Z0-9]]").WithMessage("PasswordHash must contain atleast one special character")
            .NotEqual("password", StringComparer.OrdinalIgnoreCase)
            .WithMessage("password cannot be password.");
    }
}