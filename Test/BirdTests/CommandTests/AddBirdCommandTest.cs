using Application.Commands.Birds.AddBirds;
using Application.Dtos.Animals;
using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class AddBirdCommandTest
    {
        private AddBirdCommandHandler _handler;
        private Mock<caDBContext> _dbMockContext;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _dbMockContext = new Mock<caDBContext>();
            _handler = new AddBirdCommandHandler(_dbMockContext.Object);
        }
        protected void SetupMockDbContext(List<Bird> birds)
        {
            var mockDbSet = new Mock<DbSet<Bird>>();
            mockDbSet.As<IQueryable<Bird>>().Setup(m => m.Provider).Returns(birds.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Bird>>().Setup(m => m.Expression).Returns(birds.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Bird>>().Setup(m => m.ElementType).Returns(birds.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Bird>>().Setup(m => m.GetEnumerator()).Returns(birds.GetEnumerator());

            _dbMockContext.Setup(b => b.Birds).Returns(mockDbSet.Object);
        }

        [Test]
        public async Task Handle_ValidCommand_AddNewBird()
        {
            // Arrange
            var birds = new List<Bird>();
            SetupMockDbContext(birds);

            var command = new AddBirdCommand(new BirdDto { Name = "NewBird" });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result.Name, Is.EqualTo("NewBird"));
        }

        [Test]
        public async Task Handle_InValidCommand_EmptyBirdName()
        {
            // Arrange
            var command = new AddBirdCommand(new BirdDto { Name = "" });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}