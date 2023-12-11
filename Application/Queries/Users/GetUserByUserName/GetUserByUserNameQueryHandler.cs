using Domain.Models;
using Infrastructure.Authentication;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetUserByUserName
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, string>
    {
        public readonly MockDatabase _mockDatabase;
        public readonly JWTTokenGenerator _JWTTokenGenerator;

        public GetUserByUserNameQueryHandler(MockDatabase mockDatabase, JWTTokenGenerator jWTTokenGenerator)
        {
            _mockDatabase = mockDatabase;
            _JWTTokenGenerator = jWTTokenGenerator;
        }

        public Task<string> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            User user = _mockDatabase.Users.FirstOrDefault(user => user.Username == request.UserName)!;

            var token = _JWTTokenGenerator.GenerateJWTToken(user).ToString();

            return Task.FromResult(token);
        }
    }
}
