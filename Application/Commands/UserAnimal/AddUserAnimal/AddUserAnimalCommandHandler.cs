﻿using Application.Dtos.UserAnimal;
using Infrastructure.Repositories.UserAnimal;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.UserAnimal.AddUserAnimal
{
    public class AddUserAnimalCommandHandler : IRequestHandler<AddUserAnimalCommand, UserAnimalDto>
    {
        private readonly IUserAnimalRepository _repository;
        private readonly ILogger<AddUserAnimalCommandHandler> _logger;

        public AddUserAnimalCommandHandler(IUserAnimalRepository repository, ILogger<AddUserAnimalCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<UserAnimalDto> Handle(AddUserAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Attempting to add user animal relationship for User ID: {UserId} and Animal Model ID: {AnimalId}", request.UserId, request.AnimalId);

                // Logic to add user-animal relationship
                await _repository.AddUserAnimalAsync(request.UserId, request.AnimalId);

                // Create and return the DTO with necessary details
                UserAnimalDto userAnimalDto = new UserAnimalDto
                {
                    UserId = request.UserId,
                    // Populate other fields as necessary
                };

                _logger.LogInformation("Successfully added user animal relationship: {UserAnimalDto}", userAnimalDto);

                return userAnimalDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding user animal relationship for User ID: {UserId} and Animal Model ID: {AnimalId}", request.UserId, request.AnimalId);
                throw;
            }
        }
    }
}
