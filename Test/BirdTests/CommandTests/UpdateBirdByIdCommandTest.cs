using Application.Commands.Birds.UpdateBird;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;

namespace Application.Tests.Commands.Birds
{
	[TestFixture]
	public class UpdateBirdByIdCommandHandlerTests
	{
		private UpdateBirdByIdCommandHandler _handler;
		private MockDatabase _mockDatabase;

		[SetUp]
		public void Setup()

		{
			_mockDatabase = new MockDatabase();
			_handler = new UpdateBirdByIdCommandHandler(_mockDatabase);
		}

		[Test]
		public async Task Handle_UpdatesBirdInDatabase()
		{
			// Arrange
			var initialBird = new Bird { Id = Guid.NewGuid(), Name = "InitialBirdName" };
			_mockDatabase.allBirds.Add(initialBird);

			// Create an instance of UpdateBirdByIdCommand
			var command = new UpdateBirdByIdCommand(
				updatedBird: new BirdDto { Name = "UpdatedBirdName" },
				id: initialBird.Id
			);

			// Act
			var result = await _handler.Handle(command, CancellationToken.None);

			// Assert
			Assert.NotNull(result);
			Assert.IsInstanceOf<Bird>(result);

			// Check that the bird has the correct updated name
			Assert.That(result.Name, Is.EqualTo("UpdatedBirdName"));

			// Check that the bird has been updated in MockDatabase
			var updatedBirdInDatabase = _mockDatabase.allBirds.FirstOrDefault(bird => bird.Id == command.Id);
			Assert.That(updatedBirdInDatabase, Is.Not.Null);
			Assert.That(updatedBirdInDatabase.Name, Is.EqualTo("UpdatedBirdName"));
		}
	}
}