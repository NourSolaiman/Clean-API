using Application.Dtos;
using FluentValidation;

namespace Application.Validators.Bird
{
    public class BirdValidator : AbstractValidator<BirdDto>
    {
        public BirdValidator()
        {
            RuleFor(bird => bird.Name)
                .NotEmpty().WithMessage("Bird Name can not be empty!")
                .NotNull().WithMessage("Bird Name can not be NULL!");
            RuleFor(Bird => Bird.CanFly)
                .NotEmpty().WithMessage("Choose true or false");
        }

    }
}
