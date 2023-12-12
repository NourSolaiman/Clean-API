using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Cats.GetAllCats.GetCatsById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly caDBContext _caDBContext;
        public GetCatByIdQueryHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }
        public Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = _caDBContext.Cats.Where(Cat => Cat.Id == request.Id).FirstOrDefault()!;
            if (wantedCat == null)
            {
                return Task.FromResult<Cat>(null!);
            }
            return Task.FromResult(wantedCat);
        }
    }
}