using Domain.Models;
using Infrastructure.Repositories.Dogs;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        private readonly ILogger<DeleteDogByIdCommandHandler> _logger;

        public DeleteDogByIdCommandHandler(IDogRepository dogRepository, ILogger<DeleteDogByIdCommandHandler> logger)
        {
            _dogRepository = dogRepository;
            _logger = logger;
        }

        public async Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Attempting to delete dog with ID: {DogId}", request.DeletedDogId);

                Dog dogToDelete = await _dogRepository.GetByIdAsync(request.DeletedDogId);
                if (dogToDelete == null)
                {
                    _logger.LogWarning("No dog found with ID: {DogId}", request.DeletedDogId);
                    throw new InvalidOperationException("No dog with the given Id was found");
                }

                await _dogRepository.DeleteAsync(request.DeletedDogId);

                _logger.LogInformation("Dog successfully deleted with ID: {DogId}", request.DeletedDogId);

                return dogToDelete;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting dog with ID: {DogId}", request.DeletedDogId);
                throw;
            }
        }
    }
}
