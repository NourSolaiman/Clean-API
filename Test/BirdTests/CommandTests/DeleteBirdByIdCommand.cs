using Application.Birds.DeleteBird.DeleteBird;
using Application.Commands.Birds.DeleteBird;
using Infrastructure.Database;

namespace Test.Birds.DeleteBird
{
	[TestFixture]
	public class DeleteBirdByIdCommandTest
	{
		private DeleteBirdByIdCommandHandler _handler;
		private MockDatabase _mockDatabase;

		[SetUp]
		public void SetUp()
		{
			// Initialize the handler and mock database before each test
			_mockDatabase = new MockDatabase();
			_handler = new DeleteBirdByIdCommandHandler(_mockDatabase);
		}

		[Test]
		public async Task Handle_ExistingBirdId_RemovesBirdFromDatabase()
		{
			// Arrange
			var existingBirdId = _mockDatabase.allBirds[0].Id; // Assuming there's at least one bird in the mock database

			var command = new DeleteBirdByIdCommand(existingBirdId);

			// Act
			await _handler.Handle(command, CancellationToken.None);

			// Assert
			var deletedBird = _mockDatabase.allBirds.SingleOrDefault(d => d.Id == existingBirdId);
			Assert.IsNull(deletedBird);
		}

		[Test]
		public void Handle_NonExistingBirdId_DoesNotThrowException()
		{
			// Arrange
			var nonExistingBirdId = Guid.NewGuid();

			var command = new DeleteBirdByIdCommand(nonExistingBirdId);

			// Act and Assert
			Assert.DoesNotThrow(() => _handler.Handle(command, CancellationToken.None));
		}

	}
}
