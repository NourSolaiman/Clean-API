using Application.Commands.Birds.UpdateBird;
using Application.Dtos.Animals;
using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Application.Tests.Commands.Birds
{
    [TestFixture]
    public class UpdateBirdByIdCommandHandlerTests
    {
        private UpdateBirdByIdCommandHandler _handler;
        private Mock<caDBContext> _dbMockContext;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _dbMockContext = new Mock<caDBContext>();
            _handler = new UpdateBirdByIdCommandHandler(_dbMockContext.Object);
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
        public async Task Handle_ValidId_UpdatesBird()
        {
            // Arrange
            var birdId = new Guid("59d8fc74-3c94-4ed8-9a38-36b0b6b1074a");
            var bird = new List<Bird>
            {
                new Bird
                {
                    Id = birdId,
                    Name = "Nourki",
                }
            };
            SetupMockDbContext(bird);

            var updatedName = new BirdDto { Name = "NewBirdName" };
            var command = new UpdateBirdByIdCommand(updatedName, birdId);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(updatedName.Name, Is.EqualTo(command.UpdatedBird.Name));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidBirdId = Guid.NewGuid();
            var birdsList = new List<Bird>
            {
                new Bird
                {
                    Id = Guid.NewGuid(),
                    Name = "Nour",
                }
            };
            SetupMockDbContext(birdsList);
            var updatedName = new BirdDto { Name = "NewBirdName" };
            var command = new UpdateBirdByIdCommand(updatedName, invalidBirdId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }

    }
}