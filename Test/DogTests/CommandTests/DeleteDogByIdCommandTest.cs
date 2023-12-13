using Application.Commands.Dogs.DeleteDog;
using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class DeleteDogByIdCommandTest
    {
        private DeleteDogByIdCommandHandler _handler;
        private Mock<caDBContext> _dbMockContext;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _dbMockContext = new Mock<caDBContext>();
            _handler = new DeleteDogByIdCommandHandler(_dbMockContext.Object);
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
        public async Task Handle_ValidId_DeletesDog()
        {
            // Arrange
            var dogId = new Guid("12345678-1234-5678-1234-567812345678");
            var dog = new List<Dog>
            {
                new Dog
                {
                    Id = dogId
                }
            };
            SetupMockDbContext(dog);
            var command = new DeleteDogByIdCommand(dogId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(dogId));
        }

        [Test]
        public async Task Handle_InvalidId_DoesNothing()
        {
            // Arrange
            var invalidDogId = Guid.NewGuid();
            var dog = new List<Dog>();
            SetupMockDbContext(dog);

            var command = new DeleteDogByIdCommand(invalidDogId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
