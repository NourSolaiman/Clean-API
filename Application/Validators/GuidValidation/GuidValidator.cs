using FluentValidation;

namespace Application.Validators.GuidValidation
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(guid => guid)
                .NotEmpty().WithMessage("Animal Id can not be empty!")
                .NotEqual(Guid.Empty).WithMessage("Animal Id was not found!");
        }
    }
}
