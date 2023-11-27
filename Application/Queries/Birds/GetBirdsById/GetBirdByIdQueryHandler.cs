﻿using Application.Queries.Birds.GetBirdsById;
using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Birds.GetBirdById
{
	public class GetBirdByIdQueryHandler : IRequestHandler<GetBirdByIdQuery, Bird>
	{
		private readonly MockDatabase _mockDatabase;
		public GetBirdByIdQueryHandler(MockDatabase mockDatabase)
		{
			_mockDatabase = mockDatabase;
		}
		public Task<Bird> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken)
		{
			Bird wantedBird = _mockDatabase.allBirds.Where(Bird => Bird.animalId == request.Id).FirstOrDefault()!;
			return Task.FromResult(wantedBird);
		}
	}
}