using Application.Commands.Dogs.AddDog;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class AddDogCommandTest
    {
        private AddDogCommandHandler _handler;
        private Mock<caDBContext> _dbMockContext;
        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _dbMockContext = new Mock<caDBContext>();
            _handler = new AddDogCommandHandler(_dbMockContext.Object);
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
        public async Task Handle_ValidCommand_AddNewDog()
        {
            // Arrange
            var dogs = new List<Dog>();
            SetupMockDbContext(dogs);

            var command = new AddDogCommand(new DogDto { Name = "NewDog" });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result.Name, Is.EqualTo("NewDog"));
        }

        [Test]
        public async Task Handle_InValidCommand_ReturnNull()
        {
            // Arrange
            var command = new AddDogCommand(new DogDto { Name = "" });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}