using Domain.Models;
using MediatR;

namespace Application.Cats.GetAllCats.GetCatsById
{
    public class GetCatByIdQuery : IRequest<Cat>
    {
        public GetCatByIdQuery(Guid catId)
        {
            Id = catId;
        }
        public Guid Id { get; }
    }
}
