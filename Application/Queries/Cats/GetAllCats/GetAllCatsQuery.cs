using Domain.Models;
using MediatR;

namespace Application.Queries.Cats.GetAllCats
{
	public class GetAllCatsQuery : IRequest<List<Cat>>
	{
	}
}
