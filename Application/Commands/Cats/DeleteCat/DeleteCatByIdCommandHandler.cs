using Application.Commands.Cats.DeleteCat;
using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Cats.DeleteCat.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly caDBContext _caDBContext;
        public DeleteCatByIdCommandHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }

        public Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToDelete = _caDBContext.Cats.FirstOrDefault(cat => cat.Id == request.DeletedCatId)!;

            if (catToDelete != null)
            {
                _caDBContext.Cats.Remove(catToDelete);
                _caDBContext.SaveChangesAsync();
                return Task.FromResult(catToDelete);
            }
            // Cat not found
            return Task.FromResult(catToDelete)!;
        }
    }
}
