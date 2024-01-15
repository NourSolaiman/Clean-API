using Domain.Models;
using MediatR;

namespace Application.Queries.Birds.GetBirdByAttribute
{
    public class GetBirdByAttributeQuery : IRequest<List<Bird>>
    {
        public string Color { get; }
        public GetBirdByAttributeQuery(string color)
        {
            Color = color;
        }
    }
}
