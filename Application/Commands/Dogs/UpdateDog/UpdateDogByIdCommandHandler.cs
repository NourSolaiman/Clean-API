﻿using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Dogs.UpdateDog
{
	internal class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
	{
		private readonly MockDatabase _mockDatabase;
		public UpdateDogByIdCommandHandler(MockDatabase mockDatabase)
		{
			_mockDatabase = mockDatabase;
		}
		public Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
		{
			Dog dogToUpdate = _mockDatabase.allDogs.FirstOrDefault(dog => dog.animalId == request.Id)!;
			dogToUpdate.Name = request.UpdatedDog.Name;
			return Task.FromResult(dogToUpdate);
		}
	}
}
