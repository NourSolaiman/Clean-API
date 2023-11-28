using Application.Commands.Birds.AddBirds;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class AddBirdCommandTest
    {
        private AddBirdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new AddBirdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_ValidBirdData_AddsBirdToDatabase()
        {
            // Arrange
            var birdToAdd = new BirdDto
            {
                Name = "Simon",
            };

            var command = new AddBirdCommand(birdToAdd);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            var addedBird = _mockDatabase.allBirds.SingleOrDefault(d => d.Name == birdToAdd.Name);
            Assert.NotNull(addedBird);
            Assert.That(addedBird.Name, Is.EqualTo(birdToAdd.Name));
        }
    }
}