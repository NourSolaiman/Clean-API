using Application.Dtos;
using Domain.Models;
using MediatR;


namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommand : IRequest<Dog>
    {
        private Guid existingDogId;
        private DogDto updatedDogDto;

        public UpdateDogByIdCommand(DogDto updatedDog, Guid id)
        {
            UpdatedDog = updatedDog;
            Id = id;
        }

        public UpdateDogByIdCommand(Guid existingDogId, DogDto updatedDogDto)
        {
            this.existingDogId = existingDogId;
            this.updatedDogDto = updatedDogDto;
        }

        public DogDto UpdatedDog { get; }
        public Guid Id { get; }
    }
}
