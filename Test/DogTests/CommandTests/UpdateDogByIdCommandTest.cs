using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;

namespace Application.Tests.Commands.Dogs
{
    [TestFixture]
    public class UpdateDogByIdCommandHandlerTests
    {
        private UpdateDogByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void Setup()
        {
            _mockDatabase = new MockDatabase();
            _handler = new UpdateDogByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_UpdatesDogInDatabase()
        {
            // Arrange
            var initialDog = new Dog { animalId = Guid.NewGuid(), Name = "InitialDogName" };
            _mockDatabase.allDogs.Add(initialDog);

            // Create an instance of UpdateDogByIdCommand
            var command = new UpdateDogByIdCommand(
                updatedDog: new DogDto { Name = "UpdatedDogName" },
                id: initialDog.animalId
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<Dog>(result);

            // Check that the dog has the correct updated name
            Assert.That(result.Name, Is.EqualTo("UpdatedDogName"));

            // Check that the dog has been updated in MockDatabase
            var updatedDogInDatabase = _mockDatabase.allDogs.FirstOrDefault(dog => dog.animalId == command.Id);
            Assert.That(updatedDogInDatabase, Is.Not.Null);
            Assert.That(updatedDogInDatabase.Name, Is.EqualTo("UpdatedDogName"));
        }
    }
}