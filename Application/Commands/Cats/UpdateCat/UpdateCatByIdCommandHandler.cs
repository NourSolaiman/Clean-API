using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
    {
        private readonly caDBContext _caDBContext;
        public UpdateCatByIdCommandHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }
        public Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToUpdate = _caDBContext.Cats.FirstOrDefault(cat => cat.Id == request.Id)!;

            // Check if _mockDatabase.Cats is null before accessing it
            if (catToUpdate != null)
            {
                if (string.IsNullOrEmpty(catToUpdate.Name) || request.UpdatedCat.Name == "string")

                {
                    return Task.FromResult<Cat>(null!);

                }
                else
                {
                    catToUpdate.Name = request.UpdatedCat.Name;
                    catToUpdate.LikesToPlay = request.UpdatedCat.LikesToPlay;
                    return Task.FromResult(catToUpdate);
                }
            }
            // Cat not found
            return Task.FromResult(catToUpdate)!;
        }
    }
}
