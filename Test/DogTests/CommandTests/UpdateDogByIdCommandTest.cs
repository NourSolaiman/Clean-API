using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.DogTests.CommandTest
{
	[TestFixture]
	public class UpdateDogByIdCommandTest
	{
		private UpdateDogByIdCommandHandler _handler;
		private MockDatabase _mockDatabase;

		[SetUp]
		public void SetUp()
		{
			// Initialize the handler and mock database before each test
			_mockDatabase = new MockDatabase();
			_handler = new UpdateDogByIdCommandHandler(_mockDatabase);
		}

		[Test]
		public async Task Handle_ExistingDogId_UpdatesDogInDatabase()
		{
			// Arrange
			var existingDogId = _mockDatabase.allDogs[0].Id;
			var initialDogName = _mockDatabase.allDogs[0].Name;

			var updatedDogDto = new DogDto
			{
				Id = existingDogId,
				Name = "Fofi",
			};

			var command = new UpdateDogByIdCommand(existingDogId, updatedDogDto);

			// Act
			await _handler.Handle(command, default);

			// Assert
			var updatedDog = _mockDatabase.allDogs.SingleOrDefault(d => d.Id == existingDogId);
			Assert.NotNull(updatedDog);
			// Assert that the names match
			Assert.That(updatedDog.Name, Is.EqualTo(updatedDogDto.Name));
		}

		[Test]
		public void Handle_NonExistingDogId_DoesNotThrowException()
		{
			// Arrange
			var nonExistingDogId = Guid.NewGuid();

			var updatedDogDto = new DogDto
			{
				Id = nonExistingDogId,
				Name = "UpdatedDogName",
			};

			var command = new UpdateDogByIdCommand(nonExistingDogId, updatedDogDto);

			// Act and Assert
			Assert.DoesNotThrow(() => _handler.Handle(command, default));
		}
	}
}
