using Application.Commands.Birds.DeleteBird;
using Domain.Models;
using Infrastructure.Repositories.Birds;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Birds.DeleteBird.DeleteBird
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, Bird>
    {

        private readonly IBirdRepository _birdRepository;
        private readonly ILogger<DeleteBirdByIdCommandHandler> _logger;
        public DeleteBirdByIdCommandHandler(IBirdRepository birdRepository, ILogger<DeleteBirdByIdCommandHandler> logger)
        {
            _logger = logger;
            _birdRepository = birdRepository;
        }
        public async Task<Bird> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {

                _logger.LogInformation("Starting to handle DeleteBirdByIdCommand for bird ID: {BirdId}", request.DeletedBirdId);
                Bird birdToDelete = await _birdRepository.GetByIdAsync(request.DeletedBirdId);
                if (birdToDelete == null)
                {
                    _logger.LogWarning("No bird with the given ID {BirdID} was found", request.DeletedBirdId);
                    throw new InvalidOperationException("No Bird with the given id was found");
                }

                await _birdRepository.DeleteAsync(request.DeletedBirdId);

                _logger.LogInformation("The bird was successfully deleted {BirdId}", request.DeletedBirdId);

                return birdToDelete;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling deletion for bird by id {BirdId}", request.DeletedBirdId);
                throw;
            }
        }
    }
}
