using Application.Commands.Cats.DeleteCat;
using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Cats.DeleteCat.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly MockDatabase _mockDatabase;
        public DeleteCatByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToDelete = _mockDatabase.allCats.FirstOrDefault(cat => cat.Id == request.DeletedCatId)!;

            if (catToDelete == null)
            {
                throw new Exception("There is no cat with this ID");
            }
            _mockDatabase.allCats.Remove(catToDelete);
            return Task.FromResult(catToDelete)!;
        }
    }
}
