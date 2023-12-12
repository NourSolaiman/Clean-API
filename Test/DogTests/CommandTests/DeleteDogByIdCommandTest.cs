using Application.Commands.Dogs.DeleteDog;
using Infrastructure.Database;

namespace Test.DogTests.CommandTest
{
	[TestFixture]
	public class DeleteDogByIdCommandTest
	{
		private DeleteDogByIdCommandHandler _handler;
		private MockDatabase _mockDatabase;

		[SetUp]
		public void SetUp()
		{
			// Initialize the handler and mock database before each test
			_mockDatabase = new MockDatabase();
			_handler = new DeleteDogByIdCommandHandler(_mockDatabase);
		}

		[Test]
		public async Task Handle_ExistingDogId_RemovesDogFromDatabase()
		{
			// Arrange
			var existingDogId = _mockDatabase.allDogs[0].Id; // Assuming there's at least one dog in the mock database

			var command = new DeleteDogByIdCommand(existingDogId);

			// Act
			await _handler.Handle(command, CancellationToken.None);

			// Assert
			var deletedDog = _mockDatabase.allDogs.SingleOrDefault(d => d.Id == existingDogId);
			Assert.IsNull(deletedDog);
		}

		[Test]
		public void Handle_NonExistingDogId_DoesNotThrowException()
		{
			// Arrange
			var nonExistingDogId = Guid.NewGuid();

			var command = new DeleteDogByIdCommand(nonExistingDogId);

			// Act and Assert
			Assert.DoesNotThrow(() => _handler.Handle(command, CancellationToken.None));
		}

	}
}
