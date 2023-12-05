using Application.Dtos;
using FluentValidation;

namespace Application.Validators.Cat
{
    public class CatValidator : AbstractValidator<CatDto>
    {
        public CatValidator()
        {
            RuleFor(cat => cat.Name)
                .NotEmpty().WithMessage("Cat Name can not be empty!")
                .NotNull().WithMessage("Cat Name can not be NULL!");
            RuleFor(cat => cat.LikesToPlay)
                .NotEmpty().WithMessage("Choose true or false");
        }

    }
}
