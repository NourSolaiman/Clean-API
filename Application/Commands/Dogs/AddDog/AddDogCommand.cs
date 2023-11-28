using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Dogs.AddDog
{
    public class AddDogCommand : IRequest<Bird>
    {
        public AddDogCommand(DogDto newDog)
        {
            NewDog = newDog;
        }

        public DogDto NewDog { get; }

    }
}
