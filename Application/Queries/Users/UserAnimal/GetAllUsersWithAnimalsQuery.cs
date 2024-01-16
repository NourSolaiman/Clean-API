using Application.Dtos.UserAnimal;
using MediatR;

namespace Application.Queries.UserAnimal.GetAll
{
    public class GetAllUsersWithAnimalsQuery : IRequest<IEnumerable<UserAnimalDto>>
    {
    }
}
