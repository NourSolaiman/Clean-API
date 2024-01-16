using Application.Dtos.Animals;
using FluentValidation;

namespace Application.Validators.Bird
{
	public class BirdValidator : AbstractValidator<BirdDto>
	{

		public BirdValidator()
		{
			RuleFor(bird => bird.Name)
				.NotEmpty().WithMessage("Bird name can not be empty")
				.NotNull().WithMessage("Bird name can not be null");
			RuleFor(color => color.BirdColor)
				.NotEmpty().WithMessage("The bird has to have a color")
				.NotNull().WithMessage("The color can not be null");
		}
	}
}
