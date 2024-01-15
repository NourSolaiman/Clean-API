using Domain.Models;
using MediatR;

namespace Application.Queries.Dogs.GetDogByAttribute
{
    public class GetDogByAttributeQuery : IRequest<IEnumerable<Dog>>
    {
        public string Breed { get; set; }
        public int? Weight { get; set; }

        public GetDogByAttributeQuery(string breed, int? weight)
        {
            Breed = breed;
            Weight = weight;
        }
    }
}
