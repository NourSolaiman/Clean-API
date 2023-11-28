using Application.Commands.Dogs.AddDog;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.DogTests.CommandTest
{
	[TestFixture]
	public class AddDogCommandTest
	{
		private AddDogCommandHandler _handler;
		private MockDatabase _mockDatabase;

		[SetUp]
		public void SetUp()
		{
			// Initialize the handler and mock database before each test
			_mockDatabase = new MockDatabase();
			_handler = new AddDogCommandHandler(_mockDatabase);
		}

		[Test]
		public async Task Handle_ValidDogData_AddsDogToDatabase()
		{
			// Arrange
			var dogToAdd = new DogDto
			{
				Name = "Alfredo",
			};

			var command = new AddDogCommand(dogToAdd);

			// Act
			await _handler.Handle(command, CancellationToken.None);

			// Assert
			var addedDog = _mockDatabase.allDogs.SingleOrDefault(d => d.Name == dogToAdd.Name);
			Assert.NotNull(addedDog);
			Assert.That(addedDog.Name, Is.EqualTo(dogToAdd.Name));
		}
	}
}