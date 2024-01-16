using Application.Commands.UserAnimal.AddUserAnimal;
using Application.Dtos.UserAnimal;
using Application.Validators.Bird;
using Application.Validators.Cat;

using FluentValidation;

namespace Application.Validators.UserAnimal
{
	public class UserAnimalValidator : AbstractValidator<UserAnimalDto>
	{

		public UserAnimalValidator()
		{
			RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID cannot be empty.");

			RuleFor(x => x.Username)
				.NotEmpty().WithMessage("Username is required.")
				.Length(3, 20).WithMessage("Username must be between 3 and 20 characters long.");

			RuleForEach(userAnimal => userAnimal.Dogs)
				.SetValidator(new DogValidator());

			RuleForEach(userAnimal => userAnimal.Cats)
				.SetValidator(new CatValidator());


			RuleForEach(userAnimal => userAnimal.Birds)
				.SetValidator(new BirdValidator());
		}

		public object Validate(AddUserAnimalCommand command)
		{
			throw new NotImplementedException();
		}
	}


}
