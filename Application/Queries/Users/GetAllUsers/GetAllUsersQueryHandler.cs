using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Queries.Users.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly caDBContext _caDBContext;
        public GetAllUsersQueryHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }
        public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> allUsersFromDB = _caDBContext.Users.ToList();
            return Task.FromResult(allUsersFromDB);
        }
    }
}
