using Application.Cats.DeleteCat.DeleteCat;
using Application.Commands.Cats.DeleteCat;
using Infrastructure.Database;

namespace Test.Cats.DeleteCat
{
	[TestFixture]
	public class DeleteCatByIdCommandTest
	{
		private DeleteCatByIdCommandHandler _handler;
		private MockDatabase _mockDatabase;

		[SetUp]
		public void SetUp()
		{
			// Initialize the handler and mock database before each test
			_mockDatabase = new MockDatabase();
			_handler = new DeleteCatByIdCommandHandler(_mockDatabase);
		}

		[Test]
		public async Task Handle_ExistingCatId_RemovesCatFromDatabase()
		{
			// Arrange
			var existingCatId = _mockDatabase.allCats[0].Id; // Assuming there's at least one cat in the mock database

			var command = new DeleteCatByIdCommand(existingCatId);

			// Act
			await _handler.Handle(command, CancellationToken.None);

			// Assert
			var deletedCat = _mockDatabase.allCats.SingleOrDefault(d => d.Id == existingCatId);
			Assert.IsNull(deletedCat);
		}

		[Test]
		public void Handle_NonExistingCatId_ThrowException()
		{
			// Arrange
			var nonExistingCatId = Guid.NewGuid();
			var command = new DeleteCatByIdCommand(nonExistingCatId);

			// Act and Assert
			Assert.Throws<Exception>(() => _handler.Handle(command, CancellationToken.None));
		}

	}
}
