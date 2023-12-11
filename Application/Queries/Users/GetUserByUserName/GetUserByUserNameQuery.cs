using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetUserByUserName
{
    public class GetUserByUserNameQuery : IRequest<string>
    {
        public GetUserByUserNameQuery(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        public string UserName { get; }
        public string Password { get; }
    }
}
