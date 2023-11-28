using Domain.Models;
using MediatR;

namespace Application.Queries.Dogs.GetAllDogs
{
    public class GetAllDogsQuery : IRequest<List<Bird>>
    {
    }
}
