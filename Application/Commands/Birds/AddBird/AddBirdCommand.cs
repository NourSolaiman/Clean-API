﻿using Application.Dtos.Animals;
using Domain.Models;
using MediatR;

namespace Application.Commands.Birds.AddBirds
{
    public class AddBirdCommand : IRequest<Bird>
    {
        public AddBirdCommand(BirdDto newBird)
        {
            NewBird = newBird;
        }

        public BirdDto NewBird { get; }

    }
}
