using Domain.Models;
using Infrastructure.Authentication.Authorization;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Queries.Users.GetUserByUserName
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, string>
    {
        //public readonly MockDatabase _mockDatabase;
        private readonly caDBContext _caDBContext;
        public readonly IAuthRepository _authRepository;

        public GetUserByUserNameQueryHandler(caDBContext caDBContext, IAuthRepository authRepository)
        {
            _caDBContext = caDBContext;
            _authRepository = authRepository;
        }

        public Task<string> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            User user = _caDBContext.Users.FirstOrDefault(user => user.Username == request.UserName)!;
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            var token = _authRepository.GenerateJwtToken(user).ToString();

            return Task.FromResult(token);
        }
    }
}
