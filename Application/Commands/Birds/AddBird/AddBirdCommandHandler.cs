﻿using Domain.Models;
using Infrastructure.Repositories.Birds;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Birds.AddBirds
{
    public class AddBirdCommandHandler : IRequestHandler<AddBirdCommand, Bird>
    {
        private readonly IBirdRepository _birdRepository;
        private readonly ILogger<AddBirdCommandHandler> _logger;


        public AddBirdCommandHandler(IBirdRepository birdRepository, ILogger<AddBirdCommandHandler> logger)
        {
            _birdRepository = birdRepository;
            _logger = logger;
        }

        public async Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Starting to handle AddBirdCommand for bird: { BirdName}", request.NewBird.Name);
                // Create a new Bird object with the provided details including color
                Bird birdToCreate = new()
                {
                    Id = Guid.NewGuid(),
                    Name = request.NewBird.Name,
                    CanFly = request.NewBird.CanFly,
                    BirdColor = request.NewBird.BirdColor
                };

                await _birdRepository.AddAsync(birdToCreate);

                _logger.LogInformation("Bird successfully added with ID: {BirdId}", birdToCreate.Id);

                // Return the created bird
                return birdToCreate;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error occurred while handling AddBirdCommand for bird: {BirdName}", request.NewBird.Name);
                throw;
            }
        }
    }
}