using Domain.Models;
using MediatR;

namespace Application.Queries.Birds.GetAllBirds
{
    public class GetAllBirdsQuery : IRequest<List<Bird>>
    {
    }
}
