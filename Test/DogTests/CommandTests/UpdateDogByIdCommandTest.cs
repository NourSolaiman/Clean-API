using Application.Commands.Dogs.DeleteDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class UpdateDogByIdCommandTest
    {
        private UpdateDogByIdCommandHandler _handler;
        private Mock<caDBContext> _dbMockContext;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _dbMockContext = new Mock<caDBContext>();
            _handler = new UpdateDogByIdCommandHandler(_dbMockContext.Object);
        }
        protected void SetupMockDbContext(List<Dog> dogs)
        {
            var mockDbSet = new Mock<DbSet<Dog>>();
            mockDbSet.As<IQueryable<Dog>>().Setup(m => m.Provider).Returns(dogs.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Dog>>().Setup(m => m.Expression).Returns(dogs.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Dog>>().Setup(m => m.ElementType).Returns(dogs.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Dog>>().Setup(m => m.GetEnumerator()).Returns(dogs.GetEnumerator());

            _dbMockContext.Setup(d => d.Dogs).Returns(mockDbSet.Object);
        }

        [Test]
        public async Task Handle_ValidId_UpdatesDog()
        {
            // Arrange
            var dogId = new Guid("12345678-1234-5678-1234-567812345678");
            var dogsList = new List<Dog>
            {
                new Dog
                {
                    Id = dogId,
                    Name = "Nelson",
                }
            };
            SetupMockDbContext(dogsList);

            var updatedDog = new DogDto { Name = "NewDogName" };

            var command = new UpdateDogByIdCommand(updatedDog, dogId);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(updatedDog.Name, Is.EqualTo(command.UpdatedDog.Name));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnNull()
        {
            // Arrange
            var invalidDogId = Guid.NewGuid();
            var dogsList = new List<Dog>
            {
                new Dog
                {
                    Id = Guid.NewGuid(),
                    Name = "Nemar",
                }
            };
            SetupMockDbContext(dogsList);

            var updatedDog = new DogDto { Name = "NewDogName" };

            var command = new UpdateDogByIdCommand(updatedDog, invalidDogId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }

    }
}
