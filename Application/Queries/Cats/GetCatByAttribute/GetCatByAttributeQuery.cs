using Domain.Models;
using MediatR;

namespace Application.Queries.Cats.GetCatByAttribute
{
    public class GetCatByAttributeQuery : IRequest<IEnumerable<Cat>>
    {
        public string Breed { get; set; }
        public int? Weight { get; set; }

        public GetCatByAttributeQuery(string breed, int? weight)
        {
            Breed = breed;
            Weight = weight;



        }
    }
}
