using Application.Dtos;
using FluentValidation;

namespace Application.Validators.Dog
{
	public class DogValidator : AbstractValidator<DogDto>
	{
		public DogValidator()
		{
			RuleFor(dog => dog.Name)
				.NotEmpty().WithMessage("Dog Name can not be empty!")
				.NotNull().WithMessage("Dog Name can not be NULL!");
		}
	}
}
