using Application.Commands.Cats.DeleteCat;
using Domain.Models;
using Infrastructure.Repositories.Cats;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Cats.DeleteCat.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly ICatRepository _catRepository;
        private readonly ILogger<DeleteCatByIdCommandHandler> _logger;

        public DeleteCatByIdCommandHandler(ICatRepository catRepository, ILogger<DeleteCatByIdCommandHandler> logger)
        {
            _catRepository = catRepository;
            _logger = logger;
        }

        public async Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Attempting to delete cat with ID: {CatId}", request.DeletedCatId);

                Cat catToDelete = await _catRepository.GetByIdAsync(request.DeletedCatId);

                if (catToDelete == null)
                {
                    _logger.LogWarning("No cat found with ID: {CatId}", request.DeletedCatId);
                    throw new InvalidOperationException("No cat with the given id was found");
                }

                await _catRepository.DeleteAsync(request.DeletedCatId);

                _logger.LogInformation("Cat successfully deleted with ID: {CatId}", request.DeletedCatId);

                return catToDelete;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting cat with ID: {CatId}", request.DeletedCatId);
                throw;
            }
        }

    }
}
