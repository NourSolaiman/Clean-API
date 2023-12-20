using Domain.Models;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users.Register
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly AddUserCommandValidation _validator;

        public AddUserCommandHandler(IUserRepository userRepository, AddUserCommandValidation validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var registerCommandValidation = _validator.Validate(request);

            if (!registerCommandValidation.IsValid)
            {
                var allErrors = registerCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Registration error: " + string.Join("; ", allErrors));
            }

            // Password hashing using BCrypt
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password);

            var userToCreate = new User
            {
                Id = Guid.NewGuid(),
                Username = request.NewUser.Username.ToLowerInvariant(),
                PasswordHash = hashedPassword,
            };

            var createdUser = _userRepository.RegisterUser(userToCreate);

            return createdUser;
        }
    }
}