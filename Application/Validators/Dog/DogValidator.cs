using Application.Dtos.Animals;
using FluentValidation;

public class DogValidator : AbstractValidator<DogDto>
{
	public DogValidator()
	{
		RuleFor(dog => dog.Name)
		.NotEmpty().WithMessage("Dog Name can not be empty")
		.NotNull().WithMessage("Dog name can not be Null");

		RuleFor(dog => dog.Breed)
		   .NotEmpty().WithMessage("Dog Breed can not be empty")
		   .NotNull().WithMessage("Dog Breed can not be null ");

		RuleFor(dog => dog.Weight)
			.NotEmpty().WithMessage("Dog Weight can not be empty")
			.NotNull().WithMessage("Dog Weight can not be null ");
	}


}